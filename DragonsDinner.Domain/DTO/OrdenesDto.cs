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

    public ICollection<OrdenesDetallesDto> OrdenesDetalles { get; set; } = new List<OrdenesDetallesDto>();

    public bool Delivery { get; set; }
}
