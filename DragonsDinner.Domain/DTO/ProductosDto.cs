using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class ProductosDto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public int Existencia { get; set; }

    public string Descripcion { get; set; }

    public double Precio { get; set; }

    public int CategoriaId { get; set; }

    public string CategoriaNombre { get; set; }

    public string Imagen { get; set; }

    public double Costo { get; set; }

    public int Cantidad { get; set; }
}