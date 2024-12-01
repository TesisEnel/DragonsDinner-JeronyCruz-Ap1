using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsDinner.Data.Models;

public class Carritos
{
    [Key]
    public int CarritoId { get; set; }

    [ForeignKey("CarritoId")]
    public ICollection<Productos> Productos { get; set; } = new List<Productos>();

    public double Total { get; set; }

}
