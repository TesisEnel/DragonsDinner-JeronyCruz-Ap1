using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "Debe ingresar el nombre de la categoria")]
    public string Nombre { get; set; }
}
