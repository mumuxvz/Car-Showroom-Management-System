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
    public class ImageService:IImageService
    {
        readonly IImageRepository _repo;
        readonly IMapper _mapper;
        public ImageService(IImageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<int> AddImageModelService(ImageRequestModel image)
        {
           var data=_mapper.Map<ImageModel>(image);
            var ans = await _repo.AddImageModel(data);
            return ans;
        }
        public async Task<ImageRequestModel> GetImageByCarService(int id)
        {
            var data = await _repo.GetOneImageBycar(id);
            var imageRequestModel = _mapper.Map<ImageRequestModel>(data);
            return imageRequestModel;
        }
        public async Task<List<ImageRequestModel>> GetAllImageByCompany(int id)
        {
            var data=await _repo.getallimagebycarid(id);
            var images=_mapper.Map<List<ImageRequestModel>> (data);
            return images;
        }
    }
}
