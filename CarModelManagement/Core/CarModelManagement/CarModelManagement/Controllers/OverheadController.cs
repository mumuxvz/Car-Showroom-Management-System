using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.Core.Service;
using CarModelManagement.infra.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OverheadController : ControllerBase
    {
        readonly IOverheadService _ser;
        public OverheadController(IOverheadService ser)
        {
            _ser = ser;
        }
        [HttpPost]
        public async Task<IActionResult> AddOverhead([FromBody] ExpanseRequestModel data)
        {
            var ans = await _ser.IncomeorexpanseService(data);
            return Ok(ans);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> updateOverHead([FromBody] ExpanseRequestModel data,[FromRoute] int id)
        {
            var ans = await _ser.UpdateOverHeadService(data,id);
            return Ok(ans);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOverhead([FromRoute] int id)
        {
            var ans = await _ser.getallExpanses(id);
            return Ok(ans);
        }
    }
}
