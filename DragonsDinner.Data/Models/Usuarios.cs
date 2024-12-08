using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Usuarios : ApplicationUser
{
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El nombre solo debe contener letras.")]
    public string Nombres { get; set; }
    public string FotoPerfil { get; set; }

    [ForeignKey("UsuarioId")]
    public ICollection<Productos> Productos { get; set; } = new List<Productos>();

    [ForeignKey("Orden")]
    public int OrdenId { get; set; }
    public Ordenes? Orden { get; set; }
}
