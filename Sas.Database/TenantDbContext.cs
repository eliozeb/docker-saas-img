using Microsoft.EntityFrameworkCore;
using Sas.Database.Entities;

namespace Sas.Database;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)   : base(options)
    {
    }

    public DbSet<Tenant> Tenants {get; set;}

}