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

public class ProductosService(IDbContextFactory<ApplicationDbContext> DbFactory) : IProductosService
{
    public async Task<ProductosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Producto = await contexto.Productos
            .Where(e => e.ProductoId == id).Select(p => new ProductosDto()
            {
                ProductoId = p.ProductoId,
                Nombre = p.Nombre,
                Existencia = p.Existencia,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Categoria = p.Categoria,
                Imagen = p.Imagen,
                Costo = p.Costo,
            }).FirstOrDefaultAsync();
        return Producto ?? new ProductosDto();
    }

    public async Task<bool> Eliminar(int productoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .Where(e => e.ProductoId == productoId)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(ProductosDto productoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var productos = new Productos()
        {
            ProductoId = productoDto.ProductoId,
            Nombre = productoDto.Nombre,
            Existencia = productoDto.Existencia,
            Descripcion = productoDto.Descripcion,
            Precio = productoDto.Precio,
            Categoria = productoDto.Categoria,
            Imagen = productoDto.Imagen,
            Costo = productoDto.Costo,
        };
        contexto.Productos.Add(productos);
        var guardo = await contexto.SaveChangesAsync() > 0;
        productoDto.ProductoId = productos.ProductoId;
        return guardo;
    }

    private async Task<bool> Modificar(ProductosDto productoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var producto = new Productos()
        {
            ProductoId = productoDto.ProductoId,
            Nombre = productoDto.Nombre,
            Existencia = productoDto.Existencia,
            Descripcion = productoDto.Descripcion,
            Precio = productoDto.Precio,
            Categoria = productoDto.Categoria,
            Imagen = productoDto.Imagen,
            Costo = productoDto.Costo,
        };
        contexto.Update(producto);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos
            .AnyAsync(e => e.ProductoId == id);
    }

    public async Task<bool> Guardar(ProductosDto productoDto)
    {
        if (!await Existe(productoDto.ProductoId))
            return await Insertar(productoDto);
        else
            return await Modificar(productoDto);
    }

    public async Task<List<ProductosDto>> Listar(Expression<Func<ProductosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Productos.Select(p => new ProductosDto()
        {
            ProductoId = p.ProductoId,
            Nombre = p.Nombre,
            Existencia = p.Existencia,
            Descripcion = p.Descripcion,
            Precio = p.Precio,
            Categoria = p.Categoria,
            Imagen = p.Imagen,
            Costo = p.Costo,
        })
        .Where(criterio)
        .ToListAsync();
    }

    public Task<List<string>> ObtenerCategorias()
    {
        throw new NotImplementedException();
    }
}
