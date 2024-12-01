using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class OrdenesDetallesDto
{
    public int DetalleId { get; set; }

    [ForeignKey("Orden")]
    public int OrdenId { get; set; }
    public Ordenes? Orden { get; set; }

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }

    public int Cantidad { get; set; }

    public double Costo { get; set; }
}
