using DragonsDinner.Data.Models;

namespace DragonsDinner.Domain.DTO;

public class CarritosDetallesDto
{
    public int DetalleId { get; set; }

    public int CarritoId { get; set; }
    public Carritos Carrito { get; set; } = new Carritos();


    public double Total { get; set; }

    public ProductosFood Producto { get; set; } = new ProductosFood();

    public int Cantidad { get; set; }

    public double Costo { get; set; }

    public CarritosDetalles MapeoDetalle()
    {
        return new CarritosDetalles()
        {
            Producto = Producto,
            Carrito = Carrito,
            CarritoId = CarritoId,
            Cantidad = Cantidad,
            Costo = Costo
        };
    }
}