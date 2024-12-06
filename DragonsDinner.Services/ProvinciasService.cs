using DragonsDinner.Abstractions;
using DragonsDinner.Data;
using DragonsDinner.Data.Models;
using DragonsDinner.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Services;

public class ProvinciasService(IDbContextFactory<ApplicationDbContext> DbFactory) : IProvinciasService
{
    public async Task<ProvinciasDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Provincia = await contexto.Provincias
            .Where(e => e.ProvinciaId == id).Select(p => new ProvinciasDto()
            {
                ProvinciaId = p.ProvinciaId,
                Nombre = p.Nombre,
            }).FirstOrDefaultAsync();
        return Provincia ?? new ProvinciasDto();
    }

    public async Task<bool> Eliminar(int provinciaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provincias
            .Where(e => e.ProvinciaId == provinciaId)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(ProvinciasDto provinciaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var provincias = new Provincias()
        {
            ProvinciaId = provinciaDto.ProvinciaId,
            Nombre = provinciaDto.Nombre,
        };
        contexto.Provincias.Add(provincias);
        var guardo = await contexto.SaveChangesAsync() > 0;
        provinciaDto.ProvinciaId = provincias.ProvinciaId;
        return guardo;
    }

    private async Task<bool> Modificar(ProvinciasDto provinciaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var provincia = new Provincias()
        {
            ProvinciaId = provinciaDto.ProvinciaId,
            Nombre = provinciaDto.Nombre,
        };
        contexto.Update(provincia);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provincias
            .AnyAsync(e => e.ProvinciaId == id);
    }

    public async Task<bool> Guardar(ProvinciasDto provinciaDto)
    {
        if (!await Existe(provinciaDto.ProvinciaId))
            return await Insertar(provinciaDto);
        else
            return await Modificar(provinciaDto);
    }
    public async Task<List<ProvinciasDto>> Listar(Expression<Func<ProvinciasDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Provincias
            .Select(p => new ProvinciasDto
            {
                ProvinciaId = p.ProvinciaId,
                Nombre = p.Nombre,

            })
            .Where(criterio)
            .ToListAsync();
    }

}
