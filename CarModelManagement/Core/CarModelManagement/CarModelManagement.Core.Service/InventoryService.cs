using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
namespace CarModelManagement.Core.Service
{
    public class InventoryService: IInventoryService
    {
        readonly IInventoryrepository _repo;
        readonly IMapper _mapper;
        public InventoryService(IInventoryrepository repo,IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;   
        }
        public async Task<int> AdddataModelService(InventoryRequestModel compRequest)
        {
            var data = _mapper.Map<VehicleInverntory>(compRequest);
            var ans = await _repo.AddinventoryModel(data);
            return ans;
        }
        public async Task<List<data>> getalldata()
        {
            //var data = _mapper.Map<VehicleInverntory>(compRequest);
            var ans = await _repo.GetInventoryData();
            return ans;
        }
        public async Task<List<InventoryRequestModel>> GetDatasService(int id)
        { 
            var ans=await _repo.getalldata(id);
            var data=_mapper.Map<List<InventoryRequestModel>>(ans);
            return data;
        }
    }
}
