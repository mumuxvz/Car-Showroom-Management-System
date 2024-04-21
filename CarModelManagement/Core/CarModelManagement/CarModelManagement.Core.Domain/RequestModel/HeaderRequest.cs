using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.infra.Domain.Models;

namespace CarModelManagement.Core.Domain.RequestModel
{
    public class HeaderRequest
    {   
        public string Invoiceno { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string gstno { get; set; }

        public DateTime date { get; set; }

        public double subtotal { get; set; }

        public double grandtotal { get; set; }

        public int discount { get; set; }
        
        public double tax { get; set; }

        public double taxableamount { get; set; }

        public string condition { get; set; }

        public int CompanyMasterID { get; set; }



    }
}
