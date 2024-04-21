using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Domain.RequestModel
{
    public class ExpanseRequestModel
    {
        public string Description { get; set; }
        public bool InOrEX { get; set; }
        public double Amount { get; set; }
        public int CompanyMasterID { get; set; }
    }
}
