using AutoMapper;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Contract;
using CarModelManagement.infra.Contract;
namespace CarModelManagement.Core.Service
{
    public class ItemService: IItemService
    {
        readonly IItemRepository _repo;
        readonly IMapper _mapper;
        public ItemService(IItemRepository repo,IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddItemService(ItemRequestModel carRequest)
        {
            var data = _mapper.Map<ItemMaster>(carRequest);
            data.Active = true;
            var ans = await _repo.AddItemModel(data);
            return ans;
        }

    }
}
