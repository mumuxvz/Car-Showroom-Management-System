using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Domain.RequestModel
{
    public class CarRequestModel
    {
        public string Brand { get; set; }

        public string Class { get; set; }

        public string ModelName { get; set; }

        public string ModelCode { get; set; }

        public string Description { get; set; }

        public string Features { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfManufacturing { get; set; }

        public int SortOrder { get; set; }

        public int CompanyMasterID { get; set; }
    }
}
