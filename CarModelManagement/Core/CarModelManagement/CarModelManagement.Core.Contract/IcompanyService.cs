using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.Core.Domain.ResponseModel;
using CarModelManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IcompanyService
    {
        Task<int> AddCompanyModelService(CompanyRequestModel compRequest);
        Task<int> UpdateCompanyModelService(CompanyRequestModel compRequest, int id);
        Task<PagedList<CompanyResponseModel>> GetAllCompModelService(string searchTerm = null, int page = 1, int pageSize = 25);
        Task<CompanyResponseModel> GetCompModelByIdService(int id);
        Task<int> DeletecompModel(int id);
        Task<CompanyResponseModel> GetCompModelBycompanyIdService(string id);
        Task<int> findCompanyModelidService(string name);
    }
}
