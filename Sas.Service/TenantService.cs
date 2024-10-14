using Sas.Database;
using Sas.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Sas.Service.Dtos;

namespace Sas.Service
{
    /// <summary>
    /// This service hooks up the database and the service, enforcing tenancy. It acts as a wrapper around some database calls.
    /// </summary>
    public class TenantService : ITenantService
    {
        private readonly SasDbContext _dbContext;

        public TenantService(SasDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        /// <summary>
        /// Creates a new tenant with the specified subscription and tenant ID.
        /// </summary>
        /// <param name="subscription">The subscription identifier.</param>
        /// <param name="tenantID">The tenant unique identifier.</param>
        /// <returns>The created tenant.</returns>
        public async Task<Tenant> Create(string subscription, string tenantName, Guid tenantID)
        {
            if (string.IsNullOrWhiteSpace(subscription))
                throw new ArgumentException("Subscription cannot be null or whitespace.", nameof(subscription));

            var tenant = _dbContext.Tenants!.Add(new Tenant { Subscription = subscription, TenantName=tenantName, TenantID = tenantID, CreatedAt= DateTime.UtcNow }).Entity;
            await _dbContext.SaveChangesAsync();
            return tenant;
        }

        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns>A read-only list of tenants.</returns>
        public async Task<IReadOnlyList<Tenant>> GetAll() =>
            await _dbContext.Tenants!.ToListAsync();

        /// <summary>
        /// Gets a tenant by its identifier.
        /// </summary>
        /// <param name="id">The tenant identifier.</param>
        /// <returns>The tenant with the specified identifier.</returns>
        public async Task<Tenant?> GetById(int id)
        {
            return await _dbContext.Tenants!.FindAsync(id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteById(int id)
        {
            var tenant = await _dbContext.Tenants!.FindAsync(id) ?? throw new ArgumentException("Tenant not found");
            _dbContext.Tenants.Remove(tenant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Tenant?> UpdateById(int id, UpdateTenantDto request)
        {
            var tenant = await _dbContext.Tenants!.FindAsync(id) ?? throw new ArgumentException("Tenant not found");

            tenant.Subscription = request.Subscription;
            tenant.TenantName = request.TenantName;
            tenant.CreatedAt = request.CreatedAt;
            await _dbContext.SaveChangesAsync();

            return tenant;
        }
    }
}
