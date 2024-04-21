using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        readonly IInventoryService _ser;
        public InventoryController(IInventoryService ser)
        {
            _ser = ser;
        }

        [HttpPost]
        public async Task<IActionResult> AddCars([FromBody] InventoryRequestModel comp)
        {
            var ans = await _ser.AdddataModelService(comp);
            return Ok(ans);
        }
        [HttpGet]
        public async Task<IActionResult> getCardata()
        {
            var ans = await _ser.getalldata();
            return Ok(ans);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getalldata([FromRoute] int id)
        {
            var ans = await _ser.GetDatasService(id);
            return Ok(ans);
        }
    }
}
