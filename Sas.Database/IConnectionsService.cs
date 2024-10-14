namespace Sas.Database;

    /// <summary>
    /// Provides methods to get the connection string and tenant information.
    /// </summary>
    public interface IConnectionsService
    {
        /// <summary>
        /// Gets the connection string for the current tenant.
        /// </summary>
        /// <returns>The connection string.</returns>
        string GetConnectionString();

        /// <summary>
        /// Gets the tenant connection information.
        /// </summary>
        /// <returns>A <see cref="TenantConnection"/> object representing the current tenant.</returns>
        TenantConnection GetTenant();

    }