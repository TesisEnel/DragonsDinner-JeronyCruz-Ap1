using DragonsDinner.Data;

namespace DragonsDinner.Domain.DTO;

public class UsuariosDto : ApplicationUser
{
    public string FotoPerfil { get; set; } = string.Empty;

    public ICollection<ProductosDto> Productos { get; set; } = new List<ProductosDto>();

    public OrdenesDto Orden { get; set; } = new OrdenesDto();
}
