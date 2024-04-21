using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CarmodelController : Controller
    {
        readonly ICarModelService _carModelService;
        public CarmodelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getAllCar(string? searchTerm, int page = 1, int pageSize = 25) {
            var ans = await _carModelService.GetAllCarModelService(searchTerm, page, pageSize);
            return Ok(ans);
        }
        [HttpPost]

        public async Task<IActionResult> AddCar([FromBody] CarRequestModel car)
        {
            var ans = await _carModelService.AddCarModelService(car);
            return Ok(ans);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getAllCar([FromRoute] int id)
        {
            var ans = await _carModelService.GetCarModelById(id);
            return Ok(ans);
        }

        [HttpGet("companycars/{name}")]
        public async Task<IActionResult> getAllCarbyname([FromRoute] string name)
        {
            var ans = await _carModelService.getallcarmodelbycompany(name);
            return Ok(ans);
        }

        [HttpGet("cars/{id}")]
        public async Task<IActionResult> getAllCarwithcompany([FromRoute] int id,string? searchTerm, int page = 1, int pageSize = 25)
        {
            var ans = await _carModelService.GetAllCarModelByIDService(id);
            return Ok(ans);
        }
        [HttpPut("{id}")]

        
 
        public async Task<IActionResult> UpdateCarModel([FromRoute] int id, [FromBody] CarRequestModel carmodel)
        {
            var data = await _carModelService.UpdateCarModelService(carmodel, id);
            return Ok(data);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCarModel([FromRoute] int id)
        {
            var data = await _carModelService.DeletecarModel(id);
            return Ok(data);
        }
    }
}
