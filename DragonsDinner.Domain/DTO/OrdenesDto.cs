using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class OrdenesDto
{
    public int OrdenId { get; set; }

    public double Total { get; set; }

    public DateTime Fecha { get; set; }

    [ForeignKey("OrdenId")]
    public ICollection<OrdenesDetalles> OrdenesDetalles { get; set; } = new List<OrdenesDetalles>();

    public bool Delivery { get; set; }
}
