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

public class EstadosService(IDbContextFactory<ApplicationDbContext> DbFactory) : IEstadosService
{
    public async Task<EstadosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var estado = await contexto.Estados
            .Where(e => e.EstadoId == id).Select(p => new EstadosDto()
            {
                EstadoId = p.EstadoId,
                Descripcion = p.Descripcion
            }).FirstOrDefaultAsync();
        return estado ?? new EstadosDto();
    }

    public async Task<bool> Eliminar(int estadoId)
    {
		await using var contexto = await DbFactory.CreateDbContextAsync();
		var estado = await contexto.Estados.FindAsync(estadoId);

		if (estado != null)
		{
			contexto.Estados.Remove(estado);
			await contexto.SaveChangesAsync();
			return true;
		}

		return false;
	}

    private async Task<bool> Insertar(EstadosDto estadoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var estado = new Estados()
        {
            EstadoId = estadoDto.EstadoId,
            Descripcion = estadoDto.Descripcion
        };
        contexto.Estados.Add(estado);
        var guardo = await contexto.SaveChangesAsync() > 0;
        estado.EstadoId = estado.EstadoId;
        return guardo;
    }

    private async Task<bool> Modificar(EstadosDto estadoDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var estado = new Estados()
        {
            EstadoId = estadoDto.EstadoId,
            Descripcion = estadoDto.Descripcion
        };
        contexto.Estados.Update(estado);

        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }


    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estados
            .AnyAsync(e => e.EstadoId == id);
    }

    public async Task<bool> Guardar(EstadosDto estadoDto)
    {
        if (!await Existe(estadoDto.EstadoId))
            return await Insertar(estadoDto);
        else
            return await Modificar(estadoDto);
    }

    public async Task<List<EstadosDto>> Listar(Expression<Func<EstadosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estados.Select(p => new EstadosDto()
        {
            EstadoId = p.EstadoId,
            Descripcion = p.Descripcion
        })
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<bool> NombreExiste(string descripcion)
    {
		await using var contexto = await DbFactory.CreateDbContextAsync();
		return await contexto.Estados
			.AnyAsync(e => e.Descripcion == descripcion);
	}
}
