using System.ComponentModel.DataAnnotations.Schema;

namespace DragonsDinner.Data.Models;

public class Usuarios : ApplicationUser
{
    public string FotoPerfil { get; set; } = string.Empty;

    [ForeignKey("OrdenId")]
    public Ordenes Orden { get; set; } = new Ordenes();

}
