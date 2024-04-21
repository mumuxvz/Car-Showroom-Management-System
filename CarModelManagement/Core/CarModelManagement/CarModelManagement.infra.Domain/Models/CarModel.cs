using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Domain.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; } // Change the type to int

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; } // Change the type to int
        [Required]
        public string ModelName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]{10}$", ErrorMessage = "Model code should be 10 alphanumeric characters.")]
        public string ModelCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateOfManufacturing { get; set; }

        public bool Active { get; set; } = true;

        public int SortOrder { get; set; }

        public List<ImageModel> Images { get; set; }

        public List<VehicleInverntory> VehicleInverntorys { get; set; }

        public List<ItemMaster> itemMasters { get; set; }

        [ForeignKey("CompanyMaster")]
        public int CompanyMasterID { get; set; }
        public virtual Companymaster CompanyMaster { get; set; }

    }
}
