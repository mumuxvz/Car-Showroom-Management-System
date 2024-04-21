using AutoMapper;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Service
{
    public class headerService: IHeaderService
    {
        readonly IHeaderRepository _repo;
        readonly IMapper _mapper;
        public headerService(IHeaderRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddHeaderModelService(HeaderRequest compRequest)
        {
            var data = _mapper.Map<HeaderMaster>(compRequest);
            data.Active = true;
            var ans = await _repo.AddheaderModel(data);
            return ans;
        }
        public async Task<List<HeaderMaster>> GetAllHeaderService()
        {
            var ans = await _repo.GetAllHeader();
           
            return ans;
        }

    }
}
