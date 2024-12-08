using DragonsDinner.Data;
using DragonsDinner.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class UsuariosDto : ApplicationUser
{
    public int UsuarioId { get; set; }
    public string Nombres { get; set; }
    public string FotoPerfil { get; set; }

    public ICollection<ProductosDto> Productos { get; set; } = new List<ProductosDto>();

    public int OrdenId { get; set; }
}
