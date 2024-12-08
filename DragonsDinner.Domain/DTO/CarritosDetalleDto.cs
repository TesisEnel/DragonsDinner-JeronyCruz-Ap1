using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class CarritosDetallesDto
{
    public int DetalleId { get; set; }

    public int CarritoId { get; set; }
    public Carritos Carrito { get; set; }


    public double Total { get; set; }

    public int ProductoId { get; set; }

    public string NombreProducto { get; set; }

    public string DescripcionProducto { get; set; }

    public double Precio { get; set; }

    public int Cantidad { get; set; }

    public double Costo { get; set; }
}