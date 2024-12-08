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

    public ICollection<ProductosDto> Productos { get; set; } = new List<ProductosDto>();

    public double Total { get; set; }

    public string? UsuarioId { get; set; }
}
