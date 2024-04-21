using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CarModelManagement.infra.Domain.Models
{
    public class ImageModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)] // Max size in bytes (5MB)
        public string Path { get; set; }

        public bool Active { get; set; } = true;

        [ForeignKey("CarModelId")]
        public int CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}