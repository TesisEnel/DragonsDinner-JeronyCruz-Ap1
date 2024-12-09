using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DragonsDinner.Data.Models;

public class Carritos
{
    [Key]
    public int CarritoId { get; set; }

    public bool Comprado { get; set; } 

    public double Total { get; set; }


    [ForeignKey("Id")]
    public string Id { get; set; } = string.Empty;
    public Usuarios? Usuario { get; set; } 

    [ForeignKey("CarritoId")]
    public ICollection<CarritosDetalles> ListaDeArticulos { get; set; } = new List<CarritosDetalles>();


}
