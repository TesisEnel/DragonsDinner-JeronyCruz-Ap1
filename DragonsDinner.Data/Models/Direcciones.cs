using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Direcciones
{
    [Key]
    public int DireccionId { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }
    public string Provincia { get; set; }

    [Required(ErrorMessage = "Debe ingresar un municipio")]
    [StringLength(50, ErrorMessage = "El municipio no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El municipio solo debe contener letras.")]
    public string Municipio { get; set; }

    [Required(ErrorMessage = "Debe ingresar una calle")]
    public string Calle { get; set; }

    public string Referencia { get; set; }

    [Required(ErrorMessage = "Debe ingresar un numero de casa o apartamento")]
    public string Numero { get; set; }
}
