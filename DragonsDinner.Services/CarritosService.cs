using Microsoft.EntityFrameworkCore;
using DragonsDinner.Abstractions;
using DragonsDinner.Data.Models;
using DragonsDinner.Domain.DTO;
using System.Linq.Expressions;
using DragonsDinner.Data;
using System.Runtime.CompilerServices;

namespace DragonsDinner.Services;

public class CarritosService(IDbContextFactory<ApplicationDbContext> DbFactory) : ICarritosService
{
    public async Task<CarritosDto?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var carrito = await contexto.Carritos.FirstOrDefaultAsync(c => c.CarritoId == id);

        if (carrito is null) return null;

        return Mappear(carrito);
    }
    private CarritosDto Mappear(Carritos carrito)
    {
        return new CarritosDto()
        {
            CarritoId = carrito.CarritoId,
            CarritoDetalle = Mappear(carrito.ListaDeArticulos),
            UsuarioId = carrito.Id
        };
    }
    private ICollection<CarritosDetallesDto> Mappear(ICollection<CarritosDetalles> articulos)
    {
        var ListaMapeada = new List<CarritosDetallesDto>();
            
        foreach(var articulo in articulos)
            ListaMapeada.Add(Mapeado(articulo));
        
        return ListaMapeada;
    }
    private CarritosDetallesDto Mapeado(CarritosDetalles articulo)
    {
        return new CarritosDetallesDto()
        {
            DetalleId = articulo.DetalleId,
            Carrito = articulo.Carrito,
            Producto = articulo.Producto,
            Cantidad = articulo.Cantidad,
            Costo = articulo.Costo,

        };
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
            Id = carritoDto.UsuarioId,
            Comprado = carritoDto.Comprado,
            Total = carritoDto.Total,
            ListaDeArticulos = carritoDto.CarritoDetalle.Select(o => o.MapeoDetalle()).ToList()
        };
        contexto.Entry(carrito).State = EntityState.Added;
        foreach(var articulo in carrito.ListaDeArticulos)
        {
            contexto.Entry(articulo).State = EntityState.Added;
        }
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = new Carritos()
        {
            CarritoId = carritoDto.CarritoId,
            Comprado = carritoDto.Comprado,
            Total = carritoDto.Total,
            ListaDeArticulos = carritoDto.CarritoDetalle.Select(o => new CarritosDetalles()
            {
                DetalleId = o.DetalleId,
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
    public async Task<bool> RealizarPedido(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var carrito = new Carritos()
        {
            CarritoId = carritoDto.CarritoId,
            Id = carritoDto.UsuarioId,
            Comprado = true,  //LO SETEO EN TRUE
            Total = carritoDto.Total,
            ListaDeArticulos = carritoDto.CarritoDetalle.Select(o => o.MapeoDetalle()).ToList()
        };
        contexto.Entry(carrito).State = EntityState.Modified;

        return await contexto.SaveChangesAsync() > 0;

    }
    public async Task<CarritosDto?> Listar(string userId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var result =  await contexto.Carritos
            .Include(c => c.ListaDeArticulos).ThenInclude(a => a.Producto)
            .Include(c => c.Usuario)
            .FirstOrDefaultAsync(c => c.Id == userId && !c.Comprado);// Mi carrito pendiente por comprar

        if (result is null) return null;

        return Mappear(result);
    }


}