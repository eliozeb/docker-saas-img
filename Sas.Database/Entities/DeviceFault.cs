using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(UpdatedAt), nameof(Id))]
public class DeviceFault
{
    public int Id {get; set;}
    public string? ConfigDetail {get; set;} = default!;
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public int DeviceId {get; set;}
    public virtual Device? Device {get; set;} = default!;
}