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
                Productos = p.Productos,
                Total = p.Total
            }).FirstOrDefaultAsync();
        return carrito ?? new CarritosDto();
    }

    public async Task<bool> Eliminar(int carritoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Carritos
            .Where(e => e.CarritoId == carritoId)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = new Carritos()
        {
            Productos = carritoDto.Productos,
            Total = carritoDto.Total
        };
        contexto.Carritos.Add(carrito);
        var guardo = await contexto.SaveChangesAsync() > 0;
        carritoDto.CarritoId = carrito.CarritoId;
        return guardo;
    }

    private async Task<bool> Modificar(CarritosDto carritoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var carrito = new Carritos()
        {
            CarritoId = carritoDto.CarritoId,
            Productos = carritoDto.Productos,
            Total = carritoDto.Total
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

    public async Task<List<CarritosDto>> Listar(Expression<Func<CarritosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Carritos.Select(p => new CarritosDto()
        {
            CarritoId = p.CarritoId,
            Productos = p.Productos,
            Total = p.Total,
        })
        .Where(criterio)
        .ToListAsync();
    }
}