using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Ordenes
{
    [Key]
    public int OrdenId { get; set; }

    public double Total { get; set; }

    public DateTime Fecha { get; set; }

    [ForeignKey("OrdenId")]
    public ICollection<OrdenesDetalles> OrdenesDetalles { get; set; } = new List<OrdenesDetalles>();

    [Required(ErrorMessage = "Debe seleccioanar un metodo de entrega")]
    public bool Delivery { get; set; }
}
