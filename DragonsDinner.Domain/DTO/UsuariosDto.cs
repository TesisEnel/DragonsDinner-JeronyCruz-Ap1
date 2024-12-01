using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class UsuariosDto
{
    public int UsuarioId { get; set; }
    public string Nombres { get; set; }
    public string FotoPerfil { get; set; }

    [ForeignKey("UsuarioId")]
    public ICollection<Productos> Productos { get; set; } = new List<Productos>();

    [ForeignKey("Orden")]
    public int OrdenId { get; set; }
    public Ordenes? Orden { get; set; }
}
