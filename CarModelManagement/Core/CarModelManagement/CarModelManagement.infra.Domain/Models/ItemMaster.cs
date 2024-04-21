using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarModelManagement.infra.Domain.Models;

public class ItemMaster
{
    public int Id { get; set; }
    [Required]
    public string car_name { get; set; }
    [Required]
    public string model { get; set;}
    [Required]
    public int year { get; set;}
    [Required]
    public string color { get; set;}
    [Required]
    public double price { get; set;}
    [Required]
    public string description { get; set;}

    public bool Active { get; set; } = true;
    [ForeignKey("HeaderMaster")]
    public int HeaderMasterID { get; set; }
    public virtual HeaderMaster HeaderMaster { get; set; }

    [ForeignKey("CarModel")]
    public int carModelId { get; set; }
    public virtual CarModel CarModel { get; set; }
    

}
