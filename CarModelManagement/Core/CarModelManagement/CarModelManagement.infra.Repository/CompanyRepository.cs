using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.Shared;
using Microsoft.EntityFrameworkCore;
namespace CarModelManagement.infra.Repository;

public class CompanyRepository: ICompanyRepository
{
    readonly CarModelContext _context;
    public CompanyRepository(CarModelContext context)
    {
        _context = context;
    }
    public async Task<PagedList<Companymaster>> GetAllCompanyAsync(string searchTerm = null, int page = 1, int pageSize = 10)
    {

        var list = _context.Companymaster.Where(x => x.Active == true).AsQueryable();
        //return list;
        if (!string.IsNullOrEmpty(searchTerm))
        {
            list = list.Where(x =>
                EF.Functions.Like(x.Name, $"%{searchTerm}%") 
            );
        }
        var count = await list.LongCountAsync();
        var pagedList = list.ToPagedList(page, pageSize, count);

        return pagedList;
    }
    public async Task<Companymaster> GetOneCompanyAsync(int id)
    {

        var data = await _context.Companymaster.FirstOrDefaultAsync(x => x.ID == id);
        if (data == null || data.Active == false)
        {
            throw new Exception("carmodel not found");
        }
        return data;
    }
    public async Task<Companymaster> GetOneCompanybynameAsync(string name)
    {

        var data = await _context.Companymaster.FirstOrDefaultAsync(x => x.companyAdminUsername == name);
        if (data == null || data.Active == false)
        {
            throw new Exception("carmodel not found");
        }
        return data;
    }
    public async Task<int> AddCompanyModel(Companymaster comp)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Companymaster.Add(comp);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return comp.ID;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw new BadRequestException("transaction error try another time");
                }
            }
        });
    }
    public async Task<int> Companyid(string name)
    {
        var data = await _context.Companymaster.FirstOrDefaultAsync(x => x.companyAdminUsername == name);
        return data.ID;
    }
    public async Task<int> UpdateCompanyModel(Companymaster comp)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Companymaster.Update(comp);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return comp.ID;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw new BadRequestException("transaction error try another time");
                }
            }
        });
    }
    public async Task<int> DeleteCompanyModel(int id)
    {
        var strategy = _context.Database.CreateExecutionStrategy();

        return await strategy.ExecuteAsync(async () =>
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var data = await _context.Companymaster.FirstOrDefaultAsync(x => x.ID == id);

                    if (data != null)
                    {
                        data.Active = false;
                        _context.Companymaster.Update(data);
                        await _context.SaveChangesAsync();
                    }


                    await transaction.CommitAsync();

                    return id;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw new BadRequestException("Transaction error. Please try again.");
                }
            }
        });
    }

}
