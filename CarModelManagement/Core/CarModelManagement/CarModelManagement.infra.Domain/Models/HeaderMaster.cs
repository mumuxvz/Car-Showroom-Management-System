using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarModelManagement.infra.Domain.Models;

public class HeaderMaster
{
    public int id { get; set; }

    [Required]
    public string Invoiceno { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    public string address { get; set; }

    [Required]
    [CustomGSTValidation]
    public string gstno { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime date { get; set; }

    [Required]
    public double subtotal { get; set; }

    [Required] 
    public double grandtotal { get; set; }

    [Required]
    public int discount { get; set; }

    [Required]
    public double tax { get; set; }

    [Required]
    public double taxableamount { get; set; }

    [Required]
    public string condition { get; set; }

    public bool Active { get; set; } = true;
    [ForeignKey("CompanyMaster")]
    public int CompanyMasterID { get; set; }
    public virtual Companymaster CompanyMaster { get; set; }

    public virtual List<ItemMaster> ItemMaster { get; set; }

}
