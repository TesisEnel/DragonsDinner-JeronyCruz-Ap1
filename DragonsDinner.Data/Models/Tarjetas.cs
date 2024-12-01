using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Tarjetas
{
    [Key]
    public int TarjetaId { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El nombre solo debe contener letras.")]
    public string Nombres { get; set; }

    [Required(ErrorMessage = "El número de tarjeta es obligatorio")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "El número de tarjeta debe tener 16 dígitos")]
    public string NumeroTarjeta { get; set; }

    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "El formato debe ser MM/AA")]
    public string FechaVencimiento { get; set; }

    [Required(ErrorMessage = "El CVV es obligatorio.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "El CVV debe contener 3 o 4 dígitos.")]
    public string CVV { get; set; }
}

