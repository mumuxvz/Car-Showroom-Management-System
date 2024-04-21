using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Domain.RequestModel;

public class ItemRequestModel
{
    public string car_name { get; set; }
    
    public string model { get; set; }
    
    public int year { get; set; }

    public string color { get; set; }
    
    public double price { get; set; }
    
    public string description { get; set; }

    public int HeaderMasterID { get; set; }

    public int carModelId { get; set; }
}
