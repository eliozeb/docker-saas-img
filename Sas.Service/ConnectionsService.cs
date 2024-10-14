using Microsoft.Extensions.Options;
using Sas.Database;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Sas.Service
{
    /// <summary>
    /// The primary function of this class is to intercept incoming HTTP requests, check that
    /// there is a tenant named in the header, and match that name with a known tenant.
    /// </summary>
    public class ConnectionsService : IConnectionsService
    {
        private readonly TenantSettings _tenantSettings;
        private readonly HttpContext? _httpContext;
        private TenantConnection? _tenant;
        private const string tenantNme = "tenant";


        public ConnectionsService(IOptions<TenantSettings> tenantSettings, IHttpContextAccessor contextAccessor)
        {
            _tenantSettings = tenantSettings.Value;
            _httpContext = contextAccessor.HttpContext;

            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue(tenantNme, out var tenantId))
                {
                    SetTenant(tenantId!);
                }
                else
                {
                    throw new Exception("Invalid Tenant!");
                }
            }
        }
        private HttpContext HttpContext => _httpContext ?? throw new InvalidOperationException("HttpContext is not available");

        public void InitializeTenant()
        {

            if (HttpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
            {

                SetTenant(tenantId!);
            }
            else
            {

                throw new Exception("Invalid Tenant!");
            }
        }

        private void SetTenant(string tenantId)
        {
            _tenant = _tenantSettings.TenantConnections?
                .FirstOrDefault(a => a.TenantName == tenantId);

            if (_tenant == null)
            {
                throw new Exception("Invalid Tenant is null!");
            }

            if (string.IsNullOrEmpty(_tenant.ConnectionString))
            {
                SetDefaultConnectionStringToCurrentTenant();
            }
        }

        private void SetDefaultConnectionStringToCurrentTenant() =>
            _tenant!.ConnectionString = _tenantSettings.DefaultConnectionString;

        public string GetConnectionString() => _tenant?.ConnectionString ?? throw new InvalidOperationException("Tenant connection string is not set.");

        public TenantConnection GetTenant() => _tenant ?? throw new InvalidOperationException("Tenant is not set.");
    }
}
