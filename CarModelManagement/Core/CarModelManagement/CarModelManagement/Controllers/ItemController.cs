using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        readonly IItemService _ser;
        public ItemController(IItemService ser)
        {
            _ser = ser;
        }
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemRequestModel comp)
        {
            var ans = await _ser.AddItemService(comp);
            return Ok(ans);
        }
    }
}
