using DragonsDinner.Abstractions;
using DragonsDinner.Data.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Services.DI;

public static class ServicesRegistrar
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.RegisterDbContextFactory();
        services.AddScoped<ICarritosService, CarritosService>();
        services.AddScoped<IMetodosPagoService, MetodosPagoService>();
        services.AddScoped<IOrdenesService, OrdenesService>();
        services.AddScoped<IProductosService, ProductosService>();
        services.AddScoped<IDireccionesService, DireccionesService>();
        services.AddScoped<ITarjetasService, TarjetasService>();
        services.AddScoped<IUsuariosService, UsuariosService>();
        services.AddScoped<ICategoriasService, CategoriasService>();
        services.AddScoped<IUsuariosService, UsuariosService>();

        return services;
    }

}