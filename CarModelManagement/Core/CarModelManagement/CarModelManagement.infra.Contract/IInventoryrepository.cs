using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract
{
    public interface IInventoryrepository
    {
        Task<int> AddinventoryModel(VehicleInverntory carModel);
        Task<List<data>> GetInventoryData();
        Task<List<VehicleInverntory>> getalldata(int id);
    }
}
