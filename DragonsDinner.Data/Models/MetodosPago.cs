using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class MetodosPago
{
    [Key]
    public int MetodoPagoId { get; set; }

    [Required(ErrorMessage = "Seleccione un metodo de pago")]
    public bool MetodoPago { get; set; }

    [ForeignKey("Tarjeta")]
    [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una tarjeta")]
    public int TarjetaId { get; set; }
    public Tarjetas? Tarjeta { get; set; }
}
