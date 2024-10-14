using Sas.Database.Entities;
using Sas.Service.Dtos;
namespace Sas.Service;

public interface ITenantService
{
    Task<Tenant> Create(string Subscription, string TenantName, Guid TenantID);
    Task<Tenant?> GetById(int Id);
    Task<IReadOnlyList<Tenant>> GetAll();
    Task DeleteById(int id);
    Task<Tenant?> UpdateById(int id, UpdateTenantDto request);
}