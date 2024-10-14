using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(TenantId),nameof(DeviceID), nameof(Id))]
public class Device
{
    public int Id {get; set;}
    public Guid DeviceID {get; set;} = default!; // User Defined Id or Manufacturing Number or Similar
    public string? DeviceName {get; set; } = default!;
    public string? LocationDescriptor {get; set;} = default!;
    public string? Status {get; set;} = default!;
    public string? BatteryStatus {get; set;} = default!;
    public int? TenantId { get; set; } = default!;
    public virtual Tenant Tenant { get; set; } = default!; // Foreign Key to Tenant
    public DateTime CreatedAt {get; set;}

    public virtual ICollection<Alert> AlertUpdates {get; } = new List<Alert>();

    public virtual ICollection<Event> EventUpdates {get; } = new List<Event>();

    public virtual ICollection<HubConfiguration> HubConfigurationUpdates {get; } = new List<HubConfiguration>();

    public virtual ICollection<DeviceFault> DeviceFaultUpdates {get; } = new List<DeviceFault>();
}

public enum BatteryStatus {
    [Display(Name="Device Status 1")] Status1=1,
    [Display(Name="Device Status 2")] Status2=2,
    [Display(Name="Device Status 3")] Status3=3,
    [Display(Name="Device Status 4")] Status4=4 }