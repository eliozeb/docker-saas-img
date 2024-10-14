using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(ResolvedAt), nameof(Id))]
public class HubConfiguration
{
    public int Id {get; set;}
    public string? Description {get; set;} = default!;
    public Status Status {get; set;} = default!;
    public DateTime DetectedAt {get; set;}
    public DateTime ResolvedAt {get; set;}
    public int DeviceId {get; set;}
    public virtual Device? Device {get; set;}= default!;
}

public enum Status {
    [Display(Name="Active")] Status1=1,
    [Display(Name="Isolated")] Status2=2,
    [Display(Name="Sleep")] Status3=3,
    [Display(Name="Out of Service")] Status4=4 }