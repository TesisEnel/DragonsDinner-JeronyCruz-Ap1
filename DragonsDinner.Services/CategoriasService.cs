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

public class CategoriasService(IDbContextFactory<ApplicationDbContext> DbFactory) : ICategoriasService
{
    public async Task<CategoriasDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var categoria = await contexto.Categorias
            .Where(e => e.CategoriaId == id).Select(p => new CategoriasDto()
            {
                CategoriaId = p.CategoriaId,
                Nombre = p.Nombre
            }).FirstOrDefaultAsync();
        return categoria ?? new CategoriasDto();
    }

    public async Task<bool> Eliminar(int categoria)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var categoriaEntity = await contexto.Categorias.FindAsync(categoria);

        if (categoriaEntity != null)
        {
            contexto.Categorias.Remove(categoriaEntity);
            await contexto.SaveChangesAsync();
            return true;
        }

        return false;
    }

    private async Task<bool> Insertar(CategoriasDto categoriaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var categoria = new Categorias()
        {
            CategoriaId = categoriaDto.CategoriaId,
            Nombre = categoriaDto.Nombre
        };
        contexto.Categorias.Add(categoria);
        var guardo = await contexto.SaveChangesAsync() > 0;
        categoria.CategoriaId = categoria.CategoriaId;
        return guardo;
    }

    private async Task<bool> Modificar(CategoriasDto categoriaDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var categoria = new Categorias()
        {
            CategoriaId = categoriaDto.CategoriaId,
            Nombre = categoriaDto.Nombre
        };
        contexto.Categorias.Update(categoria);

        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }


    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Categorias
            .AnyAsync(e => e.CategoriaId == id);
    }

    public async Task<bool> Guardar(CategoriasDto categoriaDto)
    {
        if (!await Existe(categoriaDto.CategoriaId))
            return await Insertar(categoriaDto);
        else
            return await Modificar(categoriaDto);
    }

    public async Task<List<CategoriasDto>> Listar(Expression<Func<CategoriasDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Categorias.Select(p => new CategoriasDto()
        {
            CategoriaId = p.CategoriaId,
            Nombre = p.Nombre
        })
        .Where(criterio)
        .ToListAsync();
    }

    public async Task<bool> NombreExiste(string NombreCategoria)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var numeroNormalizado = NombreCategoria.Trim().ToLower();
        return await contexto.Categorias
            .AnyAsync(t => t.Nombre.Trim().ToLower() == numeroNormalizado);
    }
}