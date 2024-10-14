
namespace Sas.Service.Dtos;

public class CreateTenantDtos {
    public string Subscription {get; set;} = default!;
    public string TenantName { get; set; } = default!;
    public Guid TenantId {get; set;} = default!;
}