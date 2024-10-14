using AutoMapper;
using Sas.Service.Dtos;
using Sas.Database.Entities;

namespace Sas.Service.Mappers;

public class TenantMapper : Profile
{
    public TenantMapper()
    {
        CreateMap<Tenant, TenantDto>();
    }
}