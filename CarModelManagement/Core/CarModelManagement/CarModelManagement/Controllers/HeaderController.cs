using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        readonly IHeaderService _ser;
        public HeaderController(IHeaderService ser)
        {
            _ser = ser;
        }
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] HeaderRequest comp)
        {
            var ans = await _ser.AddHeaderModelService(comp);
            return Ok(ans);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHeader()
        { 
            var ans=await _ser.GetAllHeaderService();
            return Ok(ans);
        }

    }
}
