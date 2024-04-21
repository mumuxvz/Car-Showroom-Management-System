using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarModelManagement.Core.Domain.RequestModel
{
    public class ImageRequestModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int CarModelId { get; set; }

        public IFormFile formFile { get; set; }
    }
}
