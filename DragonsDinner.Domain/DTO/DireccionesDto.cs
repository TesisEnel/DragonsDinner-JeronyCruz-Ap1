using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Domain.DTO;

public class DireccionesDto
{
    public int DireccionId { get; set; }

    public string? Nombre { get; set; }
    public int ProvinciaId { get; set; }

    public string ProvinciaNombre { get; set; }

    public string Municipio { get; set; }

    public string Calle { get; set; }

    public string? Referencia { get; set; }

    public string Numero { get; set; }
}
