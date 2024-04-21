using Microsoft.AspNetCore.Http;

namespace CarModelManagement.infra.Domain.Models
{
    public class ImageFormFile
    {
        
            public IFormFile File { get; set; }
            public string FileName { get; set; }
    }
}