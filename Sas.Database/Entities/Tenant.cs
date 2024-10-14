using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(TenantName), nameof(Id), nameof(TenantID))]
public class Tenant : IHasTenant
{
    public int Id {get; set;}
    public string TenantName { get; set; } = default!;
    public string Subscription {get; set; } = default!;
    public DateTime CreatedAt {get; set;}
    public Guid TenantID {get; set;}
    public virtual ICollection<Device> DeviceUpdates {get; } = new List<Device>();
    public virtual ICollection<User> UserUpdates {get; } = new List<User>();
}