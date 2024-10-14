using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Sas.Database.Entities;

[Index(nameof(EventType), nameof(Id))]
public class Event
{
    public int Id {get; set;}
    public EventType EventType { get; set;}
    public DateTime EventTime {get; set;}
    public int DeviceId {get; set;}
    public virtual Device? Device {get; set;} = default!;
    public string? Description {get; set;} = default!;
    public Action Action {get; set;}
    //public int UserId {get; set;}
    //public virtual User? User {get; set;}= default!;
}

public enum EventType {
    [Display(Name="Event Type 1")] EventType1=1,
    [Display(Name="Event Type 2")] EventType2=2,
    [Display(Name="Event Type 3")] EventType3=3,
    [Display(Name="Event Type 4")] EventType4=4 }

public enum Action {
    [Display(Name="Action 1")] Action1=1,
    [Display(Name="Action 2")] Action2=2,
    [Display(Name="Action 3")] Action3=3,
    [Display(Name="Action 4")] Action4 =4}