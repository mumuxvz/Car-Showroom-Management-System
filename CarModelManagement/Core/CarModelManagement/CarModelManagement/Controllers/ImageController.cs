using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarModelManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : Controller
{
    readonly IImageService _image;
    public ImageController(IImageService image)
    {
        _image = image;
    }
    [HttpPost]
    public async Task<IActionResult> AddCar([FromForm] ImageRequestModel img)
    {
        var ans = await _image.AddImageModelService(img);
        return Ok(ans);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarImage(int id)
    { 
        var ans=await _image.GetImageByCarService(id);
        return Ok(ans);
    }
    [HttpGet("car/{id}")]
    public async Task<IActionResult> getallimagebycar(int id)
    {
        var ans = await _image.GetAllImageByCompany(id);
        return Ok(ans);
    }
}
