namespace DragonsDinner.Domain.DTO;

public class CarritosDto
{
    public int CarritoId { get; set; }

    public ICollection<CarritosDetallesDto> CarritoDetalle { get; set; } = new List<CarritosDetallesDto>();

    public double Total => CarritoDetalle.Sum(c => c.Producto.Precio * c.Cantidad);

    public string UsuarioId { get; set; } = string.Empty;

    public bool Comprado { get; set; }
}
