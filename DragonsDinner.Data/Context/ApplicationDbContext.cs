using DragonsDinner.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DragonsDinner.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Carritos> Carritos { get; set; }
    public DbSet<MetodosPago> MetodosPagos { get; set; }
    public DbSet<Ordenes> Ordenes { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<CarritosDetalles> CarritosDetalles { get; set; }
    public DbSet<OrdenesDetalles> OrdenesDetalles { get; set; }
    public DbSet<Tarjetas> Tarjetas { get; set; }
    public DbSet<Direcciones> Direcciones { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    public DbSet<Provincias> Provincias { get; set; }

    public DbSet<Categorias> Categorias { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Provincias>().HasData(new List<Provincias>()
    {
        new Provincias { ProvinciaId = 1, Nombre = "Distrito Nacional" },
        new Provincias { ProvinciaId = 2, Nombre = "Azua" },
        new Provincias { ProvinciaId = 3, Nombre = "Bahoruco" },
        new Provincias { ProvinciaId = 4, Nombre = "Barahona" },
        new Provincias { ProvinciaId = 5, Nombre = "Dajabón" },
        new Provincias { ProvinciaId = 6, Nombre = "Duarte" },
        new Provincias { ProvinciaId = 7, Nombre = "Elías Piña" },
        new Provincias { ProvinciaId = 8, Nombre = "El Seibo" },
        new Provincias { ProvinciaId = 9, Nombre = "Espaillat" },
        new Provincias { ProvinciaId = 10, Nombre = "Hato Mayor" },
        new Provincias { ProvinciaId = 11, Nombre = "Hermanas Mirabal" },
        new Provincias { ProvinciaId = 12, Nombre = "Independencia" },
        new Provincias { ProvinciaId = 13, Nombre = "La Altagracia" },
        new Provincias { ProvinciaId = 14, Nombre = "La Romana" },
        new Provincias { ProvinciaId = 15, Nombre = "La Vega" },
        new Provincias { ProvinciaId = 16, Nombre = "María Trinidad Sánchez" },
        new Provincias { ProvinciaId = 17, Nombre = "Monseñor Nouel" },
        new Provincias { ProvinciaId = 18, Nombre = "Monte Cristi" },
        new Provincias { ProvinciaId = 19, Nombre = "Monte Plata" },
        new Provincias { ProvinciaId = 20, Nombre = "Pedernales" },
        new Provincias { ProvinciaId = 21, Nombre = "Peravia" },
        new Provincias { ProvinciaId = 22, Nombre = "Puerto Plata" },
        new Provincias { ProvinciaId = 23, Nombre = "Samaná" },
        new Provincias { ProvinciaId = 24, Nombre = "San Cristóbal" },
        new Provincias { ProvinciaId = 25, Nombre = "San José de Ocoa" },
        new Provincias { ProvinciaId = 26, Nombre = "San Juan" },
        new Provincias { ProvinciaId = 27, Nombre = "San Pedro de Macorís" },
        new Provincias { ProvinciaId = 28, Nombre = "Sánchez Ramírez" },
        new Provincias { ProvinciaId = 29, Nombre = "Santiago" },
        new Provincias { ProvinciaId = 30, Nombre = "Santiago Rodríguez" },
        new Provincias { ProvinciaId = 31, Nombre = "Valverde" },
        new Provincias { ProvinciaId = 32, Nombre = "Hermanas Mirabal" }
    });

        modelBuilder.Entity<Estados>().HasData(new List<Estados>()
    {
      new Estados { EstadoId = 1 , Descripcion = "Iniciado" },
      new Estados { EstadoId = 2 , Descripcion = "En proceso" },
      new Estados { EstadoId = 3 , Descripcion = "Finalizado" }
    });

        modelBuilder.Entity<Categorias>().HasData(new List<Categorias>()
        {
           new Categorias { CategoriaId = 1, Nombre = "Hamburguesas" },
           new Categorias { CategoriaId = 2, Nombre = "Hot Dogs" },
           new Categorias { CategoriaId = 3, Nombre = "Pizzas" },
           new Categorias { CategoriaId = 4, Nombre = "Tacos" },
           new Categorias { CategoriaId = 5, Nombre = "Refrescos" },
           new Categorias { CategoriaId = 6, Nombre = "Donuts" },
           new Categorias { CategoriaId = 7, Nombre = "Yaroas" },
           new Categorias { CategoriaId = 8, Nombre = "Mofongos" }
        });


        modelBuilder.Entity<Productos>().HasData(new List<Productos>()
    {
    // Hamburguesas
    new Productos { ProductoId = 1, Nombre = "Hamburguesa Clásica", Existencia = 50, Descripcion = "Hamburguesa con carne de res, queso, lechuga y tomate.", Precio = 150.00, CategoriaId = 1, Imagen = "https://images.pexels.com/photos/2702674/pexels-photo-2702674.jpeg?auto=compress&cs=tinysrgb&w=600", Costo = 100.00, Cantidad = 0  },
    new Productos { ProductoId = 2, Nombre = "Hamburguesa BBQ", Existencia = 40, Descripcion = "Hamburguesa con salsa BBQ, cebolla caramelizada y queso cheddar.", Precio = 180.00, CategoriaId = 1, Imagen = "https://images.pexels.com/photos/3915915/pexels-photo-3915915.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2", Costo = 120.00, Cantidad = 0  },
    new Productos { ProductoId = 3, Nombre = "Hamburguesa de Pollo", Existencia = 30, Descripcion = "Hamburguesa con carne de pollo, queso, lechuga y tomate.", Precio = 200.00, CategoriaId = 1, Imagen = "https://images.pexels.com/photos/13573664/pexels-photo-13573664.jpeg?auto=compress&cs=tinysrgb&w=600", Costo = 150.00,Cantidad = 0  },

    // Hot Dogs
    new Productos { ProductoId = 4, Nombre = "Hot Dog Clásico", Existencia = 60, Descripcion = "Hot dog con salchicha, ketchup y mostaza.", Precio = 80.00, CategoriaId = 2, Imagen = "https://imag.bonviveur.com/hot-dog.jpg", Costo = 50.00,Cantidad = 0 },
    new Productos { ProductoId = 5, Nombre = "Hot Dog con Queso", Existencia = 50, Descripcion = "Hot dog con salchicha, queso derretido y cebolla.", Precio = 100.00, CategoriaId = 2, Imagen = "https://img.freepik.com/fotos-premium/queso-derretido-llovizna-mostaza-hot-dog-bollo-mano_124507-125314.jpg", Costo = 70.00,Cantidad = 0  },

    // Pizzas
    new Productos { ProductoId = 6, Nombre = "Pizza Carnivora", Existencia = 20, Descripcion = "Pizza con salsa de tomate, carne molida, pepperoni queso mozzarella.", Precio = 300.00, CategoriaId = 3, Imagen = "https://imag.bonviveur.com/pizza-de-carne-picada.jpg", Costo = 200.00,Cantidad = 0  },
    new Productos { ProductoId = 7, Nombre = "Pizza Pepperoni", Existencia = 25, Descripcion = "Pizza con queso mozzarella y pepperoni.", Precio = 350.00, CategoriaId = 3, Imagen = "https://pizzeriabellaroma.es/wp-content/uploads/receta-de-pizza-de-pepperoni.jpg", Costo = 250.00,Cantidad = 0  },
    new Productos { ProductoId = 8, Nombre = "Pizza Cuatro Quesos", Existencia = 15, Descripcion = "Pizza con mezcla de cuatro tipos de quesos.", Precio = 400.00, CategoriaId = 3, Imagen = "https://www.hola.com/horizon/landscape/e8bb41b65869-pizzacuatroquesos-adob-t.jpg", Costo = 300.00,Cantidad = 0  },

    // Tacos
    new Productos { ProductoId = 9, Nombre = "Taco Clásico", Existencia = 35, Descripcion = "Taco con carne, queso y vegetales.", Precio = 100.00, CategoriaId = 4, Imagen = "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2018/09/11000515/taco-pescado-receta.jpg", Costo = 70.00,Cantidad = 0  },
    new Productos { ProductoId = 10, Nombre = "Taco de Pollo", Existencia = 30, Descripcion = "Taco con pollo, queso y salsa especial.", Precio = 120.00, CategoriaId = 4, Imagen = "https://cdn.bolivia.com/gastronomia/2018/11/30/tacos-de-pollo-3391-1.jpg", Costo = 90.00,Cantidad = 0  },

    // Refrescos
    new Productos { ProductoId = 11, Nombre = "Refresco Red Rock", Existencia = 100, Descripcion = "Refresco tradicional dominicano.", Precio = 50.00, CategoriaId = 5, Imagen = "https://supermercadosnacional.com/media/catalog/product/cache/fde49a4ea9a339628caa0bc56aea00ff/2/2/2228901-1__1720643724.jpg", Costo = 30.00,Cantidad = 0  },
    new Productos { ProductoId = 12, Nombre = "Refresco Country Club Uva", Existencia = 90, Descripcion = "Refresco de uva con sabor único dominicano.", Precio = 50.00, CategoriaId = 5, Imagen = "https://www.coca-cola.com/content/dam/onexp/do/es/brands/country-club/country_club_uva.jpg", Costo = 30.00,Cantidad = 0  },
    new Productos { ProductoId = 13, Nombre = "Refresco Country Club Merengue", Existencia = 80, Descripcion = "Refresco sabor merengue dominicano.", Precio = 50.00, CategoriaId = 5, Imagen = "https://www.coca-cola.com/content/dam/onexp/do/es/brands/country-club/country_club_merengue.jpg", Costo = 30.00, Cantidad = 0  },

    // Donuts
    new Productos { ProductoId = 14, Nombre = "Donut Glaseada", Existencia = 50, Descripcion = "Donut clásica con glaseado.", Precio = 70.00, CategoriaId = 6, Imagen = "https://img.freepik.com/fotos-premium/donut-chocolate-glaseado-chocolate-espolvorea-sobre-el_667286-842.jpg", Costo = 40.00,Cantidad = 0  },
    new Productos { ProductoId = 15, Nombre = "Donut de Chocolate", Existencia = 45, Descripcion = "Donut cubierta de chocolate.", Precio = 80.00, CategoriaId = 6, Imagen = "https://img.freepik.com/fotos-premium/donut-chocolate-glaseado-chocolate-espolvorea-sobre-el_667286-842.jpg", Costo = 50.00,Cantidad = 0  },
    new Productos { ProductoId = 16, Nombre = "Donut con Azúcar", Existencia = 40, Descripcion = "Donut espolvoreada con azúcar.", Precio = 60.00, CategoriaId = 6, Imagen = "https://i.pinimg.com/736x/02/fe/85/02fe858efe818cc76f9a7dcab1c9256f.jpg", Costo = 30.00,Cantidad = 0  },

    // Yaroas
    new Productos { ProductoId = 17, Nombre = "Yaroa de Pollo", Existencia = 25, Descripcion = "Yaroa con pollo y queso derretido.", Precio = 150.00, CategoriaId = 7, Imagen = "https://dyj6gt4964deb.cloudfront.net/images/b44d0aa7-53a3-41ac-b858-1cff970799de.jpeg", Costo = 100.00,Cantidad = 0  },
    new Productos { ProductoId = 18, Nombre = "Yaroa de Res", Existencia = 20, Descripcion = "Yaroa con carne de res y queso.", Precio = 170.00, CategoriaId = 7, Imagen = "https://www.afuegoalto.com/wp-content/uploads/2021/01/20160716_235522-01-600x338.jpeg", Costo = 120.00,Cantidad = 0  },

    // Mofongos
    new Productos { ProductoId = 19, Nombre = "Mofongo Clásico", Existencia = 15, Descripcion = "Mofongo con ajo y chicharrón.", Precio = 250.00, CategoriaId = 8, Imagen = "https://dyj6gt4964deb.cloudfront.net/images/f7a0fb38-d918-45e3-a7d7-39c2aeaedc0e.jpeg", Costo = 180.00,Cantidad = 0  },
    new Productos { ProductoId = 20, Nombre = "Mofongo con Camarones", Existencia = 10, Descripcion = "Mofongo con camarones y salsa especial.", Precio = 300.00, CategoriaId = 8, Imagen = "https://static.wixstatic.com/media/07359e_65d3c58086bc45f8ae295f10ec354ce0~mv2.jpg/v1/fill/w_480,h_480,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/07359e_65d3c58086bc45f8ae295f10ec354ce0~mv2.jpg", Costo = 220.00,Cantidad = 0  }
    });

    }

}
