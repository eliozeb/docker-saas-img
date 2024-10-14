using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(AlertType), nameof(Id))]
public class Alert
{
    public int Id {get; set;}
    public string? AlertType {get; set;} = default!;
    public bool IsActive {get; set;}
    public string? ConfigDetail {get; set;} =  default!;
    public DateTime CreatedAt {get; set;}
    public int DeviceId {get; set;}
    public virtual Device Device {get; set;} = default!;
}