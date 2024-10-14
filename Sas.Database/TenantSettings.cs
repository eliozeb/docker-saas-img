namespace Sas.Database;


public class TenantSettings
{
    public string? DefaultConnectionString { get; set; }
    public List<TenantConnection>? TenantConnections { get; set; }
}

public class TenantConnection
{
    public string? TenantName { get; set; }
    public string? ConnectionString { get; set; }
}