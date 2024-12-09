using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DragonsDinner.Data.Models;

public class Categorias
{
    [Key]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "Debe ingresar el nombre de la categoria")]
    public string Nombre { get; set; } = string.Empty;
}
