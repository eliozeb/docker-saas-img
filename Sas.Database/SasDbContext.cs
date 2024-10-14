using Sas.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Sas.Database;

/// <summary>
///
/* The main change in the preceding code is that the connection string is now read from the TenantService class that we created previously. This is far more dynamic and allows us to create new databases for new tenants on the fly as we build the app. This is also far more secure than having a connection string hardcoded in the source code and checked into the repository. Another important change to note is that we add a query filter at the context level. This ensures that only the correct tenant can read their data, which is a very important security consideration.
    Finally, we have overridden the SaveChangesAsync method. This allows us to set the tenant name here and not have to consider it in any of our other implementation code. This cleans up the rest of our code considerably.*/
/// </summary>
public class SasDbContext : DbContext
{
        private readonly IConnectionsService _connectionsService;

    public SasDbContext(DbContextOptions<SasDbContext> options,
        IConnectionsService service) : base(options) =>
         _connectionsService = service ?? throw new ArgumentNullException(nameof(service));

    public string TenantName {get => _connectionsService
        .GetTenant()?.TenantName ?? string.Empty;}

    public DbSet<Tenant>? Tenants {get; set;}
    public DbSet<Device>? Devices {get; set;}
    public DbSet<User>? Users { get; set; }
    public DbSet<HubConfiguration>? HubConfigurations { get; set; }
    public DbSet<Event>? Events { get; set; }
    public DbSet<DeviceFault>? DeviceFaults { get; set; }
    public DbSet<Alert>? Alerts { get; set; }

     protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var tenantConnectionString = _connectionsService.GetConnectionString();
                if (!string.IsNullOrEmpty(tenantConnectionString))
                {
                    optionsBuilder.UseSqlServer(tenantConnectionString);
                }
                else
                {
                    throw new Exception("Connection string is not configured.");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>().HasQueryFilter(a=>
                       a.TenantName == TenantName);
            SeedData.Seed(modelBuilder);
        }

        public override async Task<int>
            SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                ChangeTracker.Entries<IHasTenant>()
                    .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified )
                    .ToList()
                    .ForEach(entry => entry.Entity.TenantName = TenantName);
                return await base.SaveChangesAsync(cancellationToken);
            }
}