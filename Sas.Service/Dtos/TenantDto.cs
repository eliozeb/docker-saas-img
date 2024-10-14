namespace Sas.Service.Dtos;

public class TenantDto{
    public int Id { get; set;}
    public string TenantName { get; set; } = default!;
    public string Subscription {get; set; } = default!;
    public DateTime CreatedAt {get; set;}
}