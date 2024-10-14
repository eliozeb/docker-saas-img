using Sas.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;

namespace Sas.Service.Connections;

[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]

public class TenantsController : ControllerBase
{
    private readonly ILogger<TenantsController> _logger;
    private readonly ITenantService _tenantService;
    private readonly IMapper _mapper;
    public TenantsController(
            ILogger<TenantsController> logger,
            ITenantService sasService,
            IMapper mapper)
    {
        _logger = logger;
        _tenantService = sasService;
        _mapper = mapper;
    }

    [MapToApiVersion("1.0")]
    [HttpGet("version")]
    public virtual async Task<IActionResult> GetVersion()
    {
        // Simulate asynchronous work
        var result = await Task.FromResult("Response from version 1.0");
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id) {
        var tenant = await _tenantService.GetById(id);
        if (tenant == null) return NotFound(); //if so, we return NotFound(), which will return the 404 status code.
        return Ok(_mapper.Map<TenantDto>(await _tenantService.GetById(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync() => Ok(_mapper.Map<ICollection<TenantDto>>(await _tenantService.GetAll()));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTenantDtos request) {
        var tenant = await _tenantService.Create(request.Subscription, request.TenantName, request.TenantId);
        var tenantDto = _mapper.Map<TenantDto>(tenant);

        return CreatedAtAction("Get", "Tenants", new { id = tenantDto.Id }, tenantDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _tenantService.DeleteById(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, UpdateTenantDto request){
        var tenant = await _tenantService.UpdateById(id,request);
        if(tenant == null)
        {
            return NotFound();
        }

        return Ok(tenant);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<UpdateTenantDto> patch){
        var tenant = await _tenantService.GetById(id);
        if(tenant == null) return NotFound();

        var updateTenantDto= new UpdateTenantDto {
            Subscription = tenant.Subscription,
            TenantName = tenant.TenantName,
            CreatedAt = tenant.CreatedAt
        };

        try{
            patch.ApplyTo(updateTenantDto, ModelState);
            if(!TryValidateModel(updateTenantDto))
                return ValidationProblem(ModelState);
            await _tenantService.UpdateById(id, updateTenantDto);
            return NoContent();
        }
        catch(JsonPatchException ex)
        {
            return BadRequest(new {error=ex.Message });
        }
    }
}