using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract
{
    public interface IImageRepository
    {
        Task<int> AddImageModel(ImageModel comp);
        Task<ImageModel> GetOneImageBycar(int id);
        Task<List<ImageModel>> getallimagebycarid(int id);
    }
}
