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

public class TarjetasService(IDbContextFactory<ApplicationDbContext> DbFactory) : ITarjetasService
{
    public async Task<TarjetasDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var tarjeta = await contexto.Tarjetas
            .Where(e => e.TarjetaId == id).Select(p => new TarjetasDto()
            {
                TarjetaId = p.TarjetaId,
                Nombres = p.Nombres,
                NumeroTarjeta = p.NumeroTarjeta,
                FechaVencimiento = p.FechaVencimiento,
                CVV = p.CVV
            }).FirstOrDefaultAsync();
        return tarjeta ?? new TarjetasDto();
    }

    public async Task<bool> Eliminar(int tarjeta)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tarjetas
            .Where(e => e.TarjetaId == tarjeta)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(TarjetasDto tarjetaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var tarjeta = new Tarjetas()
        {
            TarjetaId = tarjetaDto.TarjetaId,
            Nombres = tarjetaDto.Nombres,
            NumeroTarjeta = tarjetaDto.NumeroTarjeta,
            FechaVencimiento = tarjetaDto.FechaVencimiento,
            CVV = tarjetaDto.CVV
        };
        contexto.Tarjetas.Add(tarjeta);
        var guardo = await contexto.SaveChangesAsync() > 0;
        tarjeta.TarjetaId = tarjeta.TarjetaId;
        return guardo;
    }

    private async Task<bool> Modificar(TarjetasDto tarjetaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var tarjeta = new Tarjetas()
        {
            TarjetaId = tarjetaDto.TarjetaId,
            Nombres = tarjetaDto.Nombres,
            NumeroTarjeta = tarjetaDto.NumeroTarjeta,
            FechaVencimiento = tarjetaDto.FechaVencimiento,
            CVV = tarjetaDto.CVV
        };
        contexto.Update(tarjetaDto);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tarjetas
            .AnyAsync(e => e.TarjetaId == id);
    }

    public async Task<bool> Guardar(TarjetasDto tarjetaDto)
    {
        if (!await Existe(tarjetaDto.TarjetaId))
            return await Insertar(tarjetaDto);
        else
            return await Modificar(tarjetaDto);
    }

    public async Task<List<TarjetasDto>> Listar(Expression<Func<TarjetasDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Tarjetas.Select(p => new TarjetasDto()
        {
            TarjetaId = p.TarjetaId,
            Nombres = p.Nombres,
            NumeroTarjeta = p.NumeroTarjeta,
            FechaVencimiento = p.FechaVencimiento,
            CVV = p.CVV
        })
        .Where(criterio)
        .ToListAsync();
    }
}
