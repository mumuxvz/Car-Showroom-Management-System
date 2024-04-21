using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.infra.Domain;
using CarModelManagement.infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.infra.Contract;
namespace CarModelManagement.infra.Repository
{
    public class OverheadRepository: IOverheadRepository
    {
        readonly CarModelContext _context;
        public OverheadRepository(CarModelContext context) 
        {
            _context = context;
        }
        public async Task<int> ExpanseorIncome(Expanse comp)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.Expanse.Add(comp);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return comp.Id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }
        public async Task<List<Expanse>> GetAllData(int id)
        {
            var data = await _context.Expanse.Where(x => x.CompanyMasterID == id).ToListAsync();
            return data;
        }
        public async Task<int> ExpanseorIncomeUpdate(Expanse comp)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {

                        _context.Expanse.Update(comp);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return comp.Id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }
        public async Task<Expanse> GetOneOverheadAsync(int id)
        {

            var data = await _context.Expanse.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                throw new Exception("overhead not found");
            }
            return data;
        }
    }
}
