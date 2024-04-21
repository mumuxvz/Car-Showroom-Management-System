using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Domain.ResponseModel
{
    public class CompanyResponseModel
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long MobileNum { get; set; }
        public string Address { get; set; }
        public string GSTNo { get; set; }
        public string email { get; set; }
    }
}
