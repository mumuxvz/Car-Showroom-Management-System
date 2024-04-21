using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Domain.Models
{
    public class Expanse
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public bool InOrEX { get; set; }
        public double Amount { get; set; }

        [ForeignKey("CompanyMaster")]
        public int CompanyMasterID { get; set; }
        public virtual Companymaster CompanyMaster { get; set; }

    }
}
