using System.ComponentModel.DataAnnotations;

namespace CarModelManagement.infra.Domain.Models;

public class Companymaster
{
    public int ID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [RegularExpression(@"^[0-9]*$")]
    [StringLength(15,MinimumLength = 10)]
    public long mobilenum { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [CustomGSTValidation]
    public string gstno { get; set; }

    [Required]
    public string email { get; set; }
    [Required]
    public string companyAdminUsername { get; set; }
    public bool Active { get; set; } = true;

    public virtual ICollection<HeaderMaster> HeaderMasters { get; set; }
    public virtual ICollection<CarModel> CarModels { get; set; }
    public virtual ICollection<Expanse> Expanses { get; set; }
    public virtual ICollection<VehicleInverntory> VehicleInverntories { get; set; }
}
