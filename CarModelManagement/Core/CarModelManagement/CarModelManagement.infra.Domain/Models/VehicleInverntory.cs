using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Domain.Models;

public class VehicleInverntory
{
    public int Id { get; set; }

    [Required]
    public int number { get; set; }

    [Required]
    public bool addorremove { get; set; }

    public string Description { get; set; }

    [ForeignKey("CarModel")]
    public int VehicleId { get; set; }
    public virtual CarModel CarModel { get; set; }

    [ForeignKey("CompanyMaster")]
    public int CompanyMasterID { get; set; }
    public virtual Companymaster CompanyMaster { get; set; }
}
