using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class CarritosDto
{
    public int CarritoId { get; set; }

    public ICollection<CarritosDetallesDto> CarritoDetalle { get; set; } = new List<CarritosDetallesDto>();

    public double Total => CarritoDetalle.Sum(c => c.Precio * c.Cantidad);

    public string? UsuarioId { get; set; }
}
