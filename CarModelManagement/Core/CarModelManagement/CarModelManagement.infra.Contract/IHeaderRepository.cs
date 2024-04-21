using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract
{
    public interface IHeaderRepository
    {
        Task<int> AddheaderModel(HeaderMaster comp);
        Task<List<HeaderMaster>> GetAllHeader();
    }
}
