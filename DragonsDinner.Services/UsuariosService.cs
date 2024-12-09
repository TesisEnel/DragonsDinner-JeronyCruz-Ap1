using DragonsDinner.Abstractions;
using Microsoft.EntityFrameworkCore;
using DragonsDinner.Data;

namespace DragonsDinner.Services;

public class UsuariosService(IDbContextFactory<ApplicationDbContext> DbFactory) : IUsuariosService
{
  
}
