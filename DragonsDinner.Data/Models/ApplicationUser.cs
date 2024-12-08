using DragonsDinner.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DragonsDinner.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<Tarjetas> Tarjetas { get; set; } = new List<Tarjetas>();
    public ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();

}
