using DragonsDinner.Data.Models;

namespace DragonsDinner.Domain.DTO;

public class ProductosDto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public int Existencia { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public double Precio { get; set; }
    public int CategoriaId { get; set; }
    public Categorias Categoria { get; set; } = new Categorias();

    public string Imagen { get; set; } = string.Empty;

    public double Costo { get; set; }

    public int Cantidad { get; set; }

    public Productos Mappear()
    {
        return new Productos()
        {
            ProductoId = ProductoId,
            Nombre = Nombre,
            Existencia = Existencia,
            Descripcion = Descripcion,
            Precio = Precio,
            CategoriaId = CategoriaId,
            Imagen = Imagen,
            Costo = Costo,
            Cantidad = Cantidad
        };
    }
}