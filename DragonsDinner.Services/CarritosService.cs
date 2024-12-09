using DragonsDinner.Abstractions;
using DragonsDinner.Data.Models;
using DragonsDinner.Data;
using DragonsDinner.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Services;

public class CarritosService(IDbContextFactory<ApplicationDbContext> DbFactory) : ICarritosService
{
    public async Task<CarritosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = await contexto.Carritos
            .Where(e => e.CarritoId == id).Select(p => new CarritosDto()
            {
                CarritoId = p.CarritoId,
                UsuarioId = p.UsuarioId,
                CarritoDetalle = p.CarritoDetalle.Select(o => new CarritosDetallesDto()
                {
                    DetalleId = o.DetalleId,
                    CarritoId = o.CarritoId,
                    ProductoId = o.ProductoId,
                    Cantidad = o.Cantidad,
                    Costo = o.Costo,
                    Imagen = o.Producto.Imagen,
                }).ToList()
            }).FirstOrDefaultAsync();
        return carrito ?? new CarritosDto();
    }

    public async Task<bool> Eliminar(int carritoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carritoEntity = await contexto.Carritos.FindAsync(carritoId);

        if (carritoEntity != null)
        {
            contexto.Carritos.Remove(carritoEntity);
            await contexto.SaveChangesAsync();
            return true;
        }

        return false;
    }

    private async Task<bool> Insertar(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = new Carritos()
        {
            Total = carritoDto.Total,
            UsuarioId = carritoDto.UsuarioId,
            CarritoDetalle = carritoDto.CarritoDetalle.Select(o => o.MapeoDetalle()).ToList()
        };
        contexto.Carritos.Add(carrito);
        var guardo = await contexto.SaveChangesAsync() > 0;
        return guardo;
    }

    private async Task<bool> Modificar(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = new Carritos()
        {
            CarritoId = carritoDto.CarritoId,
            Total = carritoDto.Total,
            UsuarioId = carritoDto.UsuarioId,
            CarritoDetalle = carritoDto.CarritoDetalle.Select(o => new CarritosDetalles()
            {
                DetalleId = o.DetalleId,
                CarritoId = o.CarritoId,
                ProductoId = o.ProductoId,
                Cantidad = o.Cantidad,
                Costo = o.Costo,
            }).ToList()
        };
        contexto.Update(carrito);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Carritos
            .AnyAsync(e => e.CarritoId == id);
    }

    public async Task<bool> Guardar(CarritosDto carrito)
    {
        if (!await Existe(carrito.CarritoId))
            return await Insertar(carrito);
        else
            return await Modificar(carrito);
    }

    public async Task<CarritosDto?> Listar(Expression<Func<CarritosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Carritos
            .Include(c => c.CarritoDetalle)
            .Select(p => new CarritosDto()
        {
            CarritoId = p.CarritoId,
            UsuarioId = p.UsuarioId
        })
        .FirstOrDefaultAsync(criterio);

    }

    public async Task<List<CarritosDto>> ObtenerCarritosPorUsuarioAsync(string usuarioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Carritos
            .Where(c => c.UsuarioId == usuarioId)
            .Select(c => new CarritosDto
            {
                CarritoId = c.CarritoId,
                UsuarioId = c.UsuarioId,
                CarritoDetalle = c.CarritoDetalle.Select(o => new CarritosDetallesDto()
                {
                    DetalleId = o.DetalleId,
                    CarritoId = o.CarritoId,
                    ProductoId = o.ProductoId,
                    Cantidad = o.Cantidad,
                    Costo = o.Costo,
                    Imagen = o.Producto.Imagen,
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<bool> IncrementarCantidad(int detalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.CarritosDetalles.FindAsync(detalleId);

        if (detalle == null) return false;

        detalle.Cantidad++;
        detalle.Costo = detalle.Cantidad * detalle.Producto.Precio; // Asume que el producto tiene un precio asociado.

        await contexto.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DecrementarCantidad(int detalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.CarritosDetalles.FindAsync(detalleId);

        if (detalle == null || detalle.Cantidad <= 1) return false;

        detalle.Cantidad--;
        detalle.Costo = detalle.Cantidad * detalle.Producto.Precio;

        await contexto.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoverDetalle(int detalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalle = await contexto.CarritosDetalles.FindAsync(detalleId);

        if (detalle == null) return false;

        contexto.CarritosDetalles.Remove(detalle);
        await contexto.SaveChangesAsync();
        return true;
    }

    public async Task<bool> VaciarCarrito(int carritoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var detalles = await contexto.CarritosDetalles
            .Where(d => d.CarritoId == carritoId)
            .ToListAsync();

        contexto.CarritosDetalles.RemoveRange(detalles);
        await contexto.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AgregarProducto(int carritoId, int productoId, int cantidad)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        // Verificar si el carrito existe
        var carrito = await contexto.Carritos.Include(c => c.CarritoDetalle)
                                              .FirstOrDefaultAsync(c => c.CarritoId == carritoId);

        if (carrito == null)
        {
            return false; // Carrito no encontrado
        }

        // Verificar si el producto ya está en el carrito
        var detalleExistente = carrito.CarritoDetalle.FirstOrDefault(d => d.ProductoId == productoId);

        if (detalleExistente != null)
        {
            // Incrementar la cantidad si ya existe
            detalleExistente.Cantidad += cantidad;
            detalleExistente.Costo = detalleExistente.Cantidad * detalleExistente.Producto.Precio; // Precio actualizado
        }
        else
        {
            // Obtener el producto desde la base de datos
            var producto = await contexto.Productos.FindAsync(productoId);

            if (producto == null)
            {
                return false; // Producto no encontrado
            }

            // Crear un nuevo detalle para el producto
            var nuevoDetalle = new CarritosDetalles
            {
                CarritoId = carritoId,
                ProductoId = productoId,
                Cantidad = cantidad,
                Costo = cantidad * producto.Precio
            };

            carrito.CarritoDetalle.Add(nuevoDetalle);
        }

        // Recalcular el total del carrito
        carrito.Total = carrito.CarritoDetalle.Sum(d => d.Costo);

        await contexto.SaveChangesAsync();
        return true;
    }


}