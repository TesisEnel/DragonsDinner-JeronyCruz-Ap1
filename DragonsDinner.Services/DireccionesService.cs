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

public class DireccionesService(IDbContextFactory<ApplicationDbContext> DbFactory) : IDireccionesService
{
    public async Task<DireccionesDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var direccion = await contexto.Direcciones
            .Where(e => e.DireccionId == id).Select(p => new DireccionesDto()
            {
                DireccionId = p.DireccionId,
                ProvinciaId = p.ProvinciaId,
                ProvinciaNombre = p.Provincia.Nombre,
                Municipio = p.Municipio,
                Calle = p.Calle,
                Referencia = p.Referencia,
                Numero = p.Numero,
                Nombre = p.Nombre,
                UsuarioId = p.UsuarioId
            }).FirstOrDefaultAsync();
        return direccion ?? new DireccionesDto();
    }

    public async Task<bool> Eliminar(int direccionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var direccion = await contexto.Direcciones.FindAsync(direccionId);

        if (direccion != null)
        {
            contexto.Direcciones.Remove(direccion);
            await contexto.SaveChangesAsync();
            return true;
        }

        return false;
    }

    private async Task<bool> Insertar(DireccionesDto direccionDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var direccion = new Direcciones()
        {
            DireccionId = direccionDto.DireccionId,
            ProvinciaId = direccionDto.ProvinciaId,
            Municipio = direccionDto.Municipio,
            Calle = direccionDto.Calle,
            Referencia = direccionDto.Referencia,
            Numero = direccionDto.Numero,
            Nombre = direccionDto.Nombre,
            UsuarioId = direccionDto.UsuarioId

        };
        contexto.Direcciones.Add(direccion);
        var guardo = await contexto.SaveChangesAsync() > 0;
        direccionDto.DireccionId = direccion.DireccionId;
        return guardo;
    }

    private async Task<bool> Modificar(DireccionesDto direccionDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var direccion = new Direcciones()
        {
            DireccionId = direccionDto.DireccionId,
            ProvinciaId = direccionDto.ProvinciaId,
            Municipio = direccionDto.Municipio,
            Calle = direccionDto.Calle,
            Referencia = direccionDto.Referencia,
            Numero = direccionDto.Numero,
            Nombre = direccionDto.Nombre,
            UsuarioId = direccionDto.UsuarioId
        };
        contexto.Update(direccion);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Direcciones
            .AnyAsync(e => e.DireccionId == id);
    }

    public async Task<bool> Guardar(DireccionesDto direccion)
    {
        if (!await Existe(direccion.DireccionId))
            return await Insertar(direccion);
        else
            return await Modificar(direccion);
    }

    public async Task<List<DireccionesDto>> Listar(Expression<Func<DireccionesDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Direcciones.Select(p => new DireccionesDto()
        {
            DireccionId = p.DireccionId,
            ProvinciaId = p.ProvinciaId,
            ProvinciaNombre = p.Provincia.Nombre,
            Municipio = p.Municipio,
            Calle = p.Calle,
            Referencia = p.Referencia,
            Numero = p.Numero,
            Nombre = p.Nombre,
            UsuarioId = p.UsuarioId
        })
        .Where(criterio)
        .ToListAsync();
    }
    public async Task<List<DireccionesDto>> ObtenerDireccionesPorUsuarioAsync(string usuarioId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var direcciones = await contexto.Direcciones
            .Where(direccion => direccion.UsuarioId == usuarioId)
            .Select(direccion => new DireccionesDto
            {
                DireccionId = direccion.DireccionId,
                ProvinciaId = direccion.ProvinciaId,
                ProvinciaNombre = direccion.Provincia.Nombre,
                Municipio = direccion.Municipio,
                Calle = direccion.Calle,
                Referencia = direccion.Referencia,
                Numero = direccion.Numero,
                Nombre = direccion.Nombre,
                UsuarioId = direccion.UsuarioId
            })
            .ToListAsync(); 


        return direcciones;
    }

}