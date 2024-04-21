using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IOverheadService
    {
        Task<int> IncomeorexpanseService(ExpanseRequestModel data);
        Task<int> UpdateOverHeadService(ExpanseRequestModel data, int id);
        Task<List<ExpanseRequestModel>> getallExpanses(int id);
    }
}
