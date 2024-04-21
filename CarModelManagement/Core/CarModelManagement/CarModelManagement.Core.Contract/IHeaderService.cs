using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IHeaderService
    {
        Task<int> AddHeaderModelService(HeaderRequest compRequest);
        Task<List<HeaderMaster>> GetAllHeaderService();
    }
}
