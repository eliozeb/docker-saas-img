using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(LastName), nameof(FirstName), nameof(Email))]
public class User
{
    public int Id {get; set;}
    public Guid UsetId {get; set;} = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? UserName {get; set;} = default!;
    public string? Password {get; set;} = default!;
    public int? TenantId {get; set;} = default!; //Which Tenant
    public virtual Tenant? Tenant {get; set;} = default!;
    public DateTime CreatedAt {get; set;}
    public Role Role {get; set;} //What is the role of the user

    //public virtual ICollection<Event> EventUpdates {get; } = new List<Event>();
}

public enum Role {
    [Display(Name="Admin")] Role1,
    [Display(Name="User")] Role2,
    [Display(Name="Guest User")] Role3,
    [Display(Name="Management")] Role4 }