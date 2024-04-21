using CarModelManagement.infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.infra.Contract;
using CarModelManagement.Core.Domain.Exceptions;
using AutoMapper;
namespace CarModelManagement.Core.Service
{
    public class OverheadService: IOverheadService
    {
        readonly IOverheadRepository _repo;
        readonly IMapper _mapper;
        public OverheadService(IOverheadRepository repo,IMapper mapper) 
        {
            _repo = repo;   
            _mapper = mapper;
        }
        public async Task<int> IncomeorexpanseService(ExpanseRequestModel data)
        {
            var data1 =_mapper.Map<Expanse>(data);
            var ans = await _repo.ExpanseorIncome(data1);
            return ans;
        }
        public async Task<List<ExpanseRequestModel>> getallExpanses(int id)
        {
            
            var ans = await _repo.GetAllData(id);
            var data= _mapper.Map<List<ExpanseRequestModel>>(ans);
            return data;
        }
        public async Task<int> UpdateOverHeadService(ExpanseRequestModel data, int id)
        {
            var data1 = await _repo.GetOneOverheadAsync(id);
            if (data == null)
            {
                throw new NotFoundException($"Candidate with {id} is not found.");
            };
            
            var ans = await _repo.ExpanseorIncomeUpdate(data1);
            return ans;
        }
    }
}
