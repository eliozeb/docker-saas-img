namespace Sas.Service.Dtos;

public class UpdateTenantDto{
    public string Subscription {get; set;} = default!;
    public string TenantName { get; set; } = default!;
    public DateTime CreatedAt {get; set;}
}