using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.Core.Contract
{
    public interface IImageService
    {
        Task<int> AddImageModelService(ImageRequestModel image);
        Task<ImageRequestModel> GetImageByCarService(int id);
        Task<List<ImageRequestModel>> GetAllImageByCompany(int id);
    }
}
