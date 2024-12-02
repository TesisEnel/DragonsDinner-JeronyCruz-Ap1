using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DragonsDinner.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.DireccionId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivery = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.TarjetaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrdenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPagos",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetodoPago = table.Column<bool>(type: "bit", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagos", x => x.MetodoPagoId);
                    table.ForeignKey(
                        name: "FK_MetodosPagos_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    CarritoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId");
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "CarritosDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritosDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CarritosDetalles_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritosDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalles_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Hamburguesas" },
                    { 2, "Hot Dogs" },
                    { 3, "Pizzas" },
                    { 4, "Tacos" },
                    { 5, "Refrescos" },
                    { 6, "Donuts" },
                    { 7, "Yaroas" },
                    { 8, "Mofongos" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Iniciado" },
                    { 2, "En proceso" },
                    { 3, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Distrito Nacional" },
                    { 2, "Azua" },
                    { 3, "Bahoruco" },
                    { 4, "Barahona" },
                    { 5, "Dajabón" },
                    { 6, "Duarte" },
                    { 7, "Elías Piña" },
                    { 8, "El Seibo" },
                    { 9, "Espaillat" },
                    { 10, "Hato Mayor" },
                    { 11, "Hermanas Mirabal" },
                    { 12, "Independencia" },
                    { 13, "La Altagracia" },
                    { 14, "La Romana" },
                    { 15, "La Vega" },
                    { 16, "María Trinidad Sánchez" },
                    { 17, "Monseñor Nouel" },
                    { 18, "Monte Cristi" },
                    { 19, "Monte Plata" },
                    { 20, "Pedernales" },
                    { 21, "Peravia" },
                    { 22, "Puerto Plata" },
                    { 23, "Samaná" },
                    { 24, "San Cristóbal" },
                    { 25, "San José de Ocoa" },
                    { 26, "San Juan" },
                    { 27, "San Pedro de Macorís" },
                    { 28, "Sánchez Ramírez" },
                    { 29, "Santiago" },
                    { 30, "Santiago Rodríguez" },
                    { 31, "Valverde" },
                    { 32, "Hermanas Mirabal" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "CarritoId", "CategoriaId", "Costo", "Descripcion", "Existencia", "Imagen", "Nombre", "Precio", "UsuarioId" },
                values: new object[,]
                {
                    { 1, null, 1, 100.0, "Hamburguesa con carne de res, queso, lechuga y tomate.", 50, "https://images.pexels.com/photos/2702674/pexels-photo-2702674.jpeg?auto=compress&cs=tinysrgb&w=600", "Hamburguesa Clásica", 150.0, null },
                    { 2, null, 1, 120.0, "Hamburguesa con salsa BBQ, cebolla caramelizada y queso cheddar.", 40, "https://images.pexels.com/photos/3915915/pexels-photo-3915915.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2", "Hamburguesa BBQ", 180.0, null },
                    { 3, null, 1, 150.0, "Hamburguesa con carne de pollo, queso, lechuga y tomate.", 30, "https://images.pexels.com/photos/13573664/pexels-photo-13573664.jpeg?auto=compress&cs=tinysrgb&w=600", "Hamburguesa de Pollo", 200.0, null },
                    { 4, null, 2, 50.0, "Hot dog con salchicha, ketchup y mostaza.", 60, "https://imag.bonviveur.com/hot-dog.jpg", "Hot Dog Clásico", 80.0, null },
                    { 5, null, 2, 70.0, "Hot dog con salchicha, queso derretido y cebolla.", 50, "https://img.freepik.com/fotos-premium/queso-derretido-llovizna-mostaza-hot-dog-bollo-mano_124507-125314.jpg", "Hot Dog con Queso", 100.0, null },
                    { 6, null, 3, 200.0, "Pizza con salsa de tomate, carne molida, pepperoni queso mozzarella.", 20, "https://imag.bonviveur.com/pizza-de-carne-picada.jpg", "Pizza Carnivora", 300.0, null },
                    { 7, null, 3, 250.0, "Pizza con queso mozzarella y pepperoni.", 25, "https://pizzeriabellaroma.es/wp-content/uploads/receta-de-pizza-de-pepperoni.jpg", "Pizza Pepperoni", 350.0, null },
                    { 8, null, 3, 300.0, "Pizza con mezcla de cuatro tipos de quesos.", 15, "https://www.hola.com/horizon/landscape/e8bb41b65869-pizzacuatroquesos-adob-t.jpg", "Pizza Cuatro Quesos", 400.0, null },
                    { 9, null, 4, 70.0, "Taco con carne, queso y vegetales.", 35, "https://s3.amazonaws.com/arc-wordpress-client-uploads/infobae-wp/wp-content/uploads/2018/09/11000515/taco-pescado-receta.jpg", "Taco Clásico", 100.0, null },
                    { 10, null, 4, 90.0, "Taco con pollo, queso y salsa especial.", 30, "https://cdn.bolivia.com/gastronomia/2018/11/30/tacos-de-pollo-3391-1.jpg", "Taco de Pollo", 120.0, null },
                    { 11, null, 5, 30.0, "Refresco tradicional dominicano.", 100, "https://supermercadosnacional.com/media/catalog/product/cache/fde49a4ea9a339628caa0bc56aea00ff/2/2/2228901-1__1720643724.jpg", "Refresco Red Rock", 50.0, null },
                    { 12, null, 5, 30.0, "Refresco de uva con sabor único dominicano.", 90, "https://www.coca-cola.com/content/dam/onexp/do/es/brands/country-club/country_club_uva.jpg", "Refresco Country Club Uva", 50.0, null },
                    { 13, null, 5, 30.0, "Refresco sabor merengue dominicano.", 80, "https://www.coca-cola.com/content/dam/onexp/do/es/brands/country-club/country_club_merengue.jpg", "Refresco Country Club Merengue", 50.0, null },
                    { 14, null, 6, 40.0, "Donut clásica con glaseado.", 50, "https://img.freepik.com/fotos-premium/donut-chocolate-glaseado-chocolate-espolvorea-sobre-el_667286-842.jpg", "Donut Glaseada", 70.0, null },
                    { 15, null, 6, 50.0, "Donut cubierta de chocolate.", 45, "https://img.freepik.com/fotos-premium/donut-chocolate-glaseado-chocolate-espolvorea-sobre-el_667286-842.jpg", "Donut de Chocolate", 80.0, null },
                    { 16, null, 6, 30.0, "Donut espolvoreada con azúcar.", 40, "https://i.pinimg.com/736x/02/fe/85/02fe858efe818cc76f9a7dcab1c9256f.jpg", "Donut con Azúcar", 60.0, null },
                    { 17, null, 7, 100.0, "Yaroa con pollo y queso derretido.", 25, "https://dyj6gt4964deb.cloudfront.net/images/b44d0aa7-53a3-41ac-b858-1cff970799de.jpeg", "Yaroa de Pollo", 150.0, null },
                    { 18, null, 7, 120.0, "Yaroa con carne de res y queso.", 20, "https://www.afuegoalto.com/wp-content/uploads/2021/01/20160716_235522-01-600x338.jpeg", "Yaroa de Res", 170.0, null },
                    { 19, null, 8, 180.0, "Mofongo con ajo y chicharrón.", 15, "https://dyj6gt4964deb.cloudfront.net/images/f7a0fb38-d918-45e3-a7d7-39c2aeaedc0e.jpeg", "Mofongo Clásico", 250.0, null },
                    { 20, null, 8, 220.0, "Mofongo con camarones y salsa especial.", 10, "https://static.wixstatic.com/media/07359e_65d3c58086bc45f8ae295f10ec354ce0~mv2.jpg/v1/fill/w_480,h_480,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/07359e_65d3c58086bc45f8ae295f10ec354ce0~mv2.jpg", "Mofongo con Camarones", 300.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CarritosDetalles_CarritoId",
                table: "CarritosDetalles",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritosDetalles_ProductoId",
                table: "CarritosDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodosPagos_TarjetaId",
                table: "MetodosPagos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalles_OrdenId",
                table: "OrdenesDetalles",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalles_ProductoId",
                table: "OrdenesDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CarritoId",
                table: "Productos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UsuarioId",
                table: "Productos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_OrdenId",
                table: "Usuarios",
                column: "OrdenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CarritosDetalles");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "MetodosPagos");

            migrationBuilder.DropTable(
                name: "OrdenesDetalles");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ordenes");
        }
    }
}
