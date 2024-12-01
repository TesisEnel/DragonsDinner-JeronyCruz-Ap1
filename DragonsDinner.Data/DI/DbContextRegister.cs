using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.DI;

public static class DbContextRegister
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>(o => o.UseSqlServer("Name=SqlConStr"));
        return services;
    }

}
