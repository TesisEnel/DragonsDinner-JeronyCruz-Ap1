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

public class MetodosPagoService(IDbContextFactory<ApplicationDbContext> DbFactory) : IMetodosPagoService
{
    public async Task<MetodosPagoDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var metodoPago = await contexto.MetodosPagos
            .Where(e => e.MetodoPagoId == id).Select(p => new MetodosPagoDto()
            {
                MetodoPagoId = p.MetodoPagoId,
                MetodoPago = p.MetodoPago,
                TarjetaId = p.TarjetaId,

            }).FirstOrDefaultAsync();
        return metodoPago ?? new MetodosPagoDto();
    }

    public async Task<bool> Eliminar(int metodoPago)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.MetodosPagos
            .Where(e => e.MetodoPagoId == metodoPago)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(MetodosPagoDto metodosPagoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var metodoPago = new MetodosPago()
        {
            MetodoPagoId = metodosPagoDto.MetodoPagoId,
            MetodoPago = metodosPagoDto.MetodoPago,
            TarjetaId = metodosPagoDto.TarjetaId,
        };
        contexto.MetodosPagos.Add(metodoPago);
        var guardo = await contexto.SaveChangesAsync() > 0;
        metodoPago.MetodoPagoId = metodoPago.MetodoPagoId;
        return guardo;
    }

    private async Task<bool> Modificar(MetodosPagoDto metodosPagoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var metodoPago = new MetodosPago()
        {
            MetodoPagoId = metodosPagoDto.MetodoPagoId,
            MetodoPago = metodosPagoDto.MetodoPago,
            TarjetaId = metodosPagoDto.TarjetaId,
        };
        contexto.Update(metodoPago);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.MetodosPagos
            .AnyAsync(e => e.MetodoPagoId == id);
    }

    public async Task<bool> Guardar(MetodosPagoDto metodoPago)
    {
        if (!await Existe(metodoPago.MetodoPagoId))
            return await Insertar(metodoPago);
        else
            return await Modificar(metodoPago);
    }

    public async Task<List<MetodosPagoDto>> Listar(Expression<Func<MetodosPagoDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.MetodosPagos.Select(p => new MetodosPagoDto()
        {
            MetodoPagoId = p.MetodoPagoId,
            MetodoPago = p.MetodoPago,
            TarjetaId = p.TarjetaId,
        })
        .Where(criterio)
        .ToListAsync();
    }
}