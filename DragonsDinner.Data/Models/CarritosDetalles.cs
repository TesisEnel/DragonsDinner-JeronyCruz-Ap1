using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DragonsDinner.Data.Models;

public class CarritosDetalles
{
    [Key]
    public int DetalleId { get; set; }

    public int CarritoId { get; set; }
    public Carritos Carrito { get; set; } = new Carritos();

    [ForeignKey("ProductoId")]
    public ProductosFood Producto { get; set; } = new ProductosFood();

    public int Cantidad { get; set; }

    public double Costo { get; set; }
}
