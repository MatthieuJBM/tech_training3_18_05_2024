using Company.Storage.Dtos;
using Company.Storage.Services;
using Microsoft.AspNetCore.Mvc;

namespace SzkolenieTechniczne.Company.Controllers;

[Microsoft.AspNetCore.Components.Route("/company")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;

    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }

    /// <summary>
    /// Gets list of companies
    /// </summary>
    /// <returns></returns>
    [HttpGet("companies")]
    public async Task<IEnumerable<CompanyDto>> Read() => await _companyService.Get();

    /// <summary>
    /// Gets company information by identifier
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("companies/{id}")]
    public async Task<IActionResult> ReadById(Guid id)
    {
        var companyDto = await _companyService.GetById(id);

        if (companyDto == null)
        {
            return NotFound();
        }

        return Ok(companyDto);
    }

    /// <summary>
    /// Creates a new company entry. The identifier of the record will be automatically generated.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("company")]
    public async Task<IActionResult> Create([FromBody] CompanyDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var operationResult = await _companyService.Create(dto);

        return Ok(operationResult);
    }
}