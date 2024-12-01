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
    public int OrdenId { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; }

    public string DescripcionProducto { get; set; }
    public int Cantidad { get; set; }

    public double Costo { get; set; }
}
