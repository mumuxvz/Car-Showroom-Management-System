using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain;
using CarModelManagement.infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace CarModelManagement.infra.Repository
{
    public class ItemRepository: IItemRepository
    {
        readonly CarModelContext _context;
        public ItemRepository(CarModelContext context) 
        {
            _context = context;
        }
        public async Task<int> AddItemModel(ItemMaster comp)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.itemmaster.Add(comp);
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

    }
}
