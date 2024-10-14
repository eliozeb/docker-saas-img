using Sas.Service;
using Sas.Database;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sas.Service", Version = "v1" }));
builder.Services.AddTransient<IConnectionsService, ConnectionsService>();
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));

// Ensure database migration
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(opt =>
 {
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
    new HeaderApiVersionReader("x-api-version"),
    new MediaTypeApiVersionReader("x-api-version"));
 });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sas.Service v1"));
}

app.UseHttpsRedirection();
app.UseRouting();

// Middleware to initialize tenant for each request
app.Use(async (context, next) =>
{
    var connectionService = context.RequestServices.GetRequiredService<IConnectionsService>();
    connectionService.GetConnectionString();

    // Set the connection string for the current request's DbContext
    var dbContext = context.RequestServices.GetService<SasDbContext>();
    dbContext?.Database.SetConnectionString(connectionService.GetConnectionString());

    await next.Invoke();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started at {Time}", DateTime.UtcNow);

app.Run();
