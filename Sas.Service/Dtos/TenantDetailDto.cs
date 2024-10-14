namespace Sas.Service.Dtos;

public class TenantDetailDto {
    public int Id { get; set;}
    public string TenantName { get; set; } = default!;
    public string Subscription {get; set; } = default!;
    public DateTime CreatedAt {get; set;}
    public Guid TenantID {get; set;}
}