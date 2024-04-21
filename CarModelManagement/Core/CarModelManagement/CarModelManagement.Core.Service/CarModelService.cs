using AutoMapper;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.Core.Domain.ResponseModel;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarModelManagement.Core.Service
{
    public class CarModelService:ICarModelService
    {
        readonly ICarModelRepository _repo;
        readonly IMapper _mapper;
        public CarModelService(ICarModelRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddCarModelService(CarRequestModel carRequest)
        {
            var data= _mapper.Map<CarModel>(carRequest);
            data.Active = true;
            var ans = await _repo.AddCarModel(data);
            return ans;
        }
        public async Task<int> UpdateCarModelService(CarRequestModel carRequest, int id)
        {
            var data = await _repo.GetOneCarAsync(id);
            if(data == null)
            {
                throw new NotFoundException($"Candidate with {id} is not found.");
            };
            var data1 = _mapper.Map(carRequest,data);
            var ans = await _repo.UpdateCarModel(data1);
            return ans;
        }
        public async Task<PagedList<CarResponseModel>> GetAllCarModelService(string searchTerm = null, int page = 1, int pageSize = 25)
        {
            var data = await _repo.GetAllCarsAsync(searchTerm,page,pageSize);
            var ans = _mapper.Map<PagedList<CarResponseModel>>(data);
            return ans;
        }
        public async Task<PagedList<CarResponseModel>> GetAllCarModelByIDService(int id,string searchTerm = null, int page = 1, int pageSize = 25)
        {
            var data = await _repo.GetallcarsByCompanyIdAsync(id,searchTerm, page, pageSize);
            var ans = _mapper.Map<PagedList<CarResponseModel>>(data);
            return ans;
        }
        public async Task<PagedList<CarResponseModel>> getallcarmodelbycompany(string name)
        {
            var data = await _repo.GetcarbyCompnay(name);
            var ans = _mapper.Map<PagedList<CarResponseModel>>(data);
            return ans;
        }
        public async Task<CarResponseModel> GetCarModelById(int id)
        {
            var data = await _repo.GetOneCarAsync(id);
            var ans=_mapper.Map<CarResponseModel>(data);
            return ans;
        }
        public async Task<int> DeletecarModel(int id)
        { 
            var model=await _repo.GetOneCarAsync(id);
            if (model == null)
            {
                throw new Exception($"Candidate with {id} is not found.");
            }
            var data=await _repo.DeleteCarModel(id);
            return data;
        }

    }
}
