using AutoMapper;
using CarModelManagement.Core.Domain.RequestModel;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Contract;
using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.Core.Domain.ResponseModel;
using CarModelManagement.Shared;

namespace CarModelManagement.Core.Service;

public class CompanyModelService:IcompanyService
{
    readonly ICompanyRepository _repo;
    readonly IMapper _mapper;
    public CompanyModelService(ICompanyRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<int> AddCompanyModelService(CompanyRequestModel compRequest)
    {
        var data = _mapper.Map<Companymaster>(compRequest);
        data.Active = true;
        var ans = await _repo.AddCompanyModel(data);
        return ans;
    }
    public async Task<int> findCompanyModelidService(string name)
    {
       var data=await _repo.GetOneCompanybynameAsync(name);
        return data.ID;
    }
    public async Task<int> UpdateCompanyModelService(CompanyRequestModel compRequest, int id)
    {
        var data = await _repo.GetOneCompanyAsync(id);
        if (data == null)
        {
            throw new NotFoundException($"Candidate with {id} is not found.");
        };
        var data1 = _mapper.Map(compRequest, data);
        var ans = await _repo.UpdateCompanyModel(data1);
        return ans;
    }
    public async Task<PagedList<CompanyResponseModel>> GetAllCompModelService(string searchTerm = null, int page = 1, int pageSize = 25)
    {
        var data = await _repo.GetAllCompanyAsync(searchTerm, page, pageSize);
        var ans = _mapper.Map<PagedList<CompanyResponseModel>>(data);
        return ans;
    }
    public async Task<CompanyResponseModel> GetCompModelByIdService(int id)
    {
        var data = await _repo.GetOneCompanyAsync(id);
        var ans = _mapper.Map<CompanyResponseModel>(data);
        return ans;
    }
    public async Task<CompanyResponseModel> GetCompModelBycompanyIdService(string id)
    {
        var data = await _repo.GetOneCompanybynameAsync(id);
        var ans = _mapper.Map<CompanyResponseModel>(data);
        return ans;
    }
    public async Task<int> DeletecompModel(int id)
    {
        var model = await _repo.GetOneCompanyAsync(id);
        if (model == null)
        {
            throw new Exception($"Candidate with {id} is not found.");
        }
        var data = await _repo.DeleteCompanyModel(id);
        return data;
    }
}
