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
    public interface ICarModelService
    {
        Task<int> AddCarModelService(CarRequestModel carRequest);
        Task<int> UpdateCarModelService(CarRequestModel carRequest, int id);
        Task<PagedList<CarResponseModel>> GetAllCarModelService(string searchTerm = null, int page = 1, int pageSize = 25);
        Task<CarResponseModel> GetCarModelById(int id);
        Task<int> DeletecarModel(int id);
        Task<PagedList<CarResponseModel>> getallcarmodelbycompany(string name);
        Task<PagedList<CarResponseModel>> GetAllCarModelByIDService(int id, string searchTerm = null, int page = 1, int pageSize = 25);

    }
}
