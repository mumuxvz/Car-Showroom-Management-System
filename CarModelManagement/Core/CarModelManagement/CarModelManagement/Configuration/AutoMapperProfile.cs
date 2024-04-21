using AutoMapper;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.Core.Domain.ResponseModel;
using CarModelManagement.Core.Service;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.infra.Repository;
using CarModelManagement.Shared;

namespace CarModelManagement.Configuration
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CarRequestModel, CarModel>();
            CreateMap<CarModel, CarResponseModel>();
            CreateMap<PagedList<CarModel>, PagedList<CarResponseModel>>();
            CreateMap<CompanyRequestModel, Companymaster>();
            CreateMap<PagedList<Companymaster>, PagedList<CompanyResponseModel>>();
            CreateMap<Companymaster, CompanyResponseModel>().ReverseMap();
            CreateMap<HeaderRequest, HeaderMaster>().ReverseMap();
            CreateMap<InventoryRequestModel,VehicleInverntory>().ReverseMap();
            CreateMap<ItemRequestModel, ItemMaster>();
            //CreateMap<ImageModel,ImageRes >();
            CreateMap<ImageRequestModel, ImageModel>();
            CreateMap<ImageModel, ImageRequestModel>();
            CreateMap<ExpanseRequestModel,Expanse>().ReverseMap();
            CreateMap<HeaderMaster, HeaderRequest>().ReverseMap();

        }
    }
}
