using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class CarritosDetalles
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Carrito")]
    public int CarritoId { get; set; }
    public Carritos? Carrito { get; set; }

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }

    public int Cantidad { get; set; }

    public double Costo { get; set; }

}
