using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain;
using CarModelManagement.infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Repository
{
    public class HeaderRepository: IHeaderRepository
    {
        private readonly CarModelContext _context; 
        public HeaderRepository(CarModelContext context) 
        {
            _context = context;
        }
        public async Task<int> AddheaderModel(HeaderMaster comp)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.headerMaster.Add(comp);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return comp.id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }
        public async Task<List<HeaderMaster>> GetAllHeader()
        {
            var data = await _context.headerMaster.Where(x=>x.CompanyMasterID==4).ToListAsync();
            return data;
        }

    }
}
