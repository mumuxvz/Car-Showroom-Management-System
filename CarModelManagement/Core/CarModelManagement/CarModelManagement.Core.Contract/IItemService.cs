using CarModelManagement.Core.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IItemService
    {
        Task<int> AddItemService(ItemRequestModel carRequest);
    }
}
