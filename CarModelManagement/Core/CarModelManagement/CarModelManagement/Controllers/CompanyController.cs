using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : Controller
{
    readonly IcompanyService _companyService;
    public CompanyController(IcompanyService compModelService)
    {
        _companyService = compModelService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] CompanyRequestModel comp)
    {
        var ans = await _companyService.AddCompanyModelService(comp);
        return Ok(ans);
    }
    [HttpGet]
    public async Task<IActionResult> getAllComp(string? searchTerm, int page = 1, int pageSize = 25)
    {
        var ans = await _companyService.GetAllCompModelService(searchTerm, page, pageSize);
        return Ok(ans);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> getOneComp([FromRoute] int id)
    {
        var ans = await _companyService.GetCompModelByIdService(id);
        return Ok(ans);
    }

    [HttpGet("company/{name}")]
    public async Task<IActionResult> getOneCompbyname([FromRoute] string name)
    {
        var ans = await _companyService.GetCompModelBycompanyIdService(name);
        return Ok(ans);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> UpdateCompModel([FromRoute] int id, [FromBody] CompanyRequestModel compmodel)
    {
        var data = await _companyService.UpdateCompanyModelService(compmodel, id);
        return Ok(data);
    }
    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteCompModel([FromRoute] int id)
    {
        var data = await _companyService.DeletecompModel(id);
        return Ok(data);
    }

    [HttpGet("compid/{name}")]
    public async Task<IActionResult> companyid([FromRoute] string name)
    {
        var data = await _companyService.GetCompModelBycompanyIdService(name);
        return Ok(data.id);
    }
}
