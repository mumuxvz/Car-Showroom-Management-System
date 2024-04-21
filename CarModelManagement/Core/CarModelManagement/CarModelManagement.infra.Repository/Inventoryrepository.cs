using CarModelManagement.infra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CarModelManagement.Core.Domain.Exceptions;
using System.Formats.Asn1;
namespace CarModelManagement.infra.Repository
{
    public class Inventoryrepository: IInventoryrepository
    {
        readonly CarModelContext _context;
        public Inventoryrepository(CarModelContext context)
        {
            _context = context;
        }
        public async Task<int> AddinventoryModel(VehicleInverntory carModel)
        {
            
                    try
                    {
                        await _context.vehicleInverntory.AddAsync(carModel);
                        await _context.SaveChangesAsync();
                        //await transaction.CommitAsync();

                        return carModel.Id;
                    }
                    catch (Exception)
                    {
                        //await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                //}
            //});

        }
        public async Task<List<VehicleInverntory>> getalldata(int id)
        {
            var data = await _context.vehicleInverntory.Where(x => x.CompanyMasterID == id).ToListAsync();
            return data;
        }
        public async Task<List<data>> GetInventoryData()
        {
            var ans = await _context.vehicleInverntory
                .GroupBy(x => x.VehicleId)
                .Select(group => new data
                {
                    carId = group.Key,

                    amount = group.Sum(x => x.addorremove ? x.number : -x.number)
                })
                .ToListAsync();

            return ans;
        }

    }
}
