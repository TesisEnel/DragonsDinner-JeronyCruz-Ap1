using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class TarjetasDto
{
    public int TarjetaId { get; set; }
    public string Nombres { get; set; }

    public string NumeroTarjeta { get; set; } = string.Empty;

    public string FechaVencimiento { get; set; }

    public string CVV { get; set; }

    public string? UsuarioId { get; set; }
}