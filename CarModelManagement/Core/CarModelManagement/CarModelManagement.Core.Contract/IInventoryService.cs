using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IInventoryService
    {
        Task<int> AdddataModelService(InventoryRequestModel compRequest);
        Task<List<data>> getalldata();
        Task<List<InventoryRequestModel>> GetDatasService(int id);
    }
}
