using CarModelManagement.infra.Domain.Models;
using CarModelManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Contract;

public interface ICompanyRepository
{
    Task<PagedList<Companymaster>> GetAllCompanyAsync(string searchTerm = null, int page = 1, int pageSize = 10);
    Task<Companymaster> GetOneCompanyAsync(int id);
    Task<int> AddCompanyModel(Companymaster comp);
    Task<int> UpdateCompanyModel(Companymaster comp);
    Task<int> DeleteCompanyModel(int id);

    Task<Companymaster> GetOneCompanybynameAsync(string name);
    Task<int> Companyid(string name);
}
