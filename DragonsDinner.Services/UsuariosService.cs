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

public class UsuariosService(IDbContextFactory<ApplicationDbContext> DbFactory) : IUsuariosService
{
    public async Task<UsuariosDto> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = await contexto.Usuarios
            .Where(e => e.UsuarioId == id).Select(p => new UsuariosDto()
            {
                UsuarioId = p.UsuarioId,
                Nombres = p.Nombres,
                FotoPerfil = p.FotoPerfil,
                Productos = p.Productos,
                Orden = p.Orden
            }).FirstOrDefaultAsync();
        return usuario ?? new UsuariosDto();
    }

    public async Task<bool> Eliminar(int usuario)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuarios
            .Where(e => e.UsuarioId == usuario)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(UsuariosDto usuarioDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = new Usuarios()
        {
            UsuarioId = usuarioDto.UsuarioId,
            Nombres = usuarioDto.Nombres,
            FotoPerfil = usuarioDto.FotoPerfil,
            Productos = usuarioDto.Productos,
            Orden = usuarioDto.Orden
        };
        contexto.Usuarios.Add(usuario);
        var guardo = await contexto.SaveChangesAsync() > 0;
        usuario.UsuarioId = usuario.UsuarioId;
        return guardo;
    }

    private async Task<bool> Modificar(UsuariosDto usuarioDto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var usuario = new Usuarios()
        {
            UsuarioId = usuarioDto.UsuarioId,
            Nombres = usuarioDto.Nombres,
            FotoPerfil = usuarioDto.FotoPerfil,
            Productos = usuarioDto.Productos,
            Orden = usuarioDto.Orden
        };
        contexto.Update(usuarioDto);
        var modificado = await contexto.SaveChangesAsync() > 0;
        return modificado;
    }

    private async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuarios
            .AnyAsync(e => e.UsuarioId == id);
    }

    public async Task<bool> Guardar(UsuariosDto usuarioDto)
    {
        if (!await Existe(usuarioDto.UsuarioId))
            return await Insertar(usuarioDto);
        else
            return await Modificar(usuarioDto);
    }

    public async Task<List<UsuariosDto>> Listar(Expression<Func<UsuariosDto, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Usuarios.Select(p => new UsuariosDto()
        {
            UsuarioId = p.UsuarioId,
            Nombres = p.Nombres,
            FotoPerfil = p.FotoPerfil,
            Productos = p.Productos,
            Orden = p.Orden
        })
        .Where(criterio)
        .ToListAsync();
    }
}
