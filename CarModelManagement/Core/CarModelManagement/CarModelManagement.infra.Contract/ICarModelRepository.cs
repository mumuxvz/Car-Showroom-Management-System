using CarModelManagement.infra.Domain.Models;
using CarModelManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract
{
    public interface ICarModelRepository
    {
        Task<PagedList<CarModel>> GetAllCarsAsync(string searchTerm = null, int page = 1, int pageSize = 5);
        Task<CarModel> GetOneCarAsync(int id);
        Task<int> AddCarModel(CarModel carModel);
        Task<int> UpdateCarModel(CarModel carModel);
        Task<int> DeleteCarModel(int id);
        Task<PagedList<CarModel>> GetcarbyCompnay(String name, int page = 1, int pageSize = 5);
        Task<PagedList<CarModel>> GetallcarsByCompanyIdAsync(int id, string searchTerm = null, int page = 1, int pageSize = 5);
    }
}
