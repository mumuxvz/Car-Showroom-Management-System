using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Domain.RequestModel
{
    public class InventoryRequestModel
    {
        public int number { get; set; }

        public bool addorremove { get; set; }

        public int VehicleId { get; set; }

        public int CompanyMasterID { get; set; }
        public string Description { get; set; }
    }
}
