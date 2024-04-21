using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CarModelManagement.Core.Domain.Exceptions;
using CarModelManagement.infra.Contract;
using CarModelManagement.infra.Domain;
using CarModelManagement.infra.Domain.Models;
using CarModelManagement.Shared;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
namespace CarModelManagement.infra.Repository
{
    public class CarModelRepository: ICarModelRepository
    {
        readonly CarModelContext _context;
        public CarModelRepository(CarModelContext context) 
        {
            _context= context;
        }
        public async Task<PagedList<CarModel>> GetAllCarsAsync(string searchTerm = null, int page = 1, int pageSize = 5)
        {
            
            var list = _context.CarModel.Where(x=>x.Active == true).AsQueryable();
            //return list;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                list = list.Where(x =>
                    EF.Functions.Like(x.Brand, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.ModelName, $"%{searchTerm}%")
                );
            }
            var count = await list.LongCountAsync();
            var pagedList = list.ToPagedList(page, pageSize, count);

            return pagedList;
        }
        public async Task<PagedList<CarModel>> GetallcarsByCompanyIdAsync(int id,string searchTerm = null, int page = 1, int pageSize = 5)
        { 
            var list=_context.CarModel.Where(x=>x.Active==true && x.CompanyMasterID==id).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                list = list.Where(x =>
                    EF.Functions.Like(x.Brand, $"%{searchTerm}%") ||
                    EF.Functions.Like(x.ModelName, $"%{searchTerm}%")
                );
            }
            var count = await list.LongCountAsync();
            var pagedList = list.ToPagedList(page, pageSize, count);

            return pagedList;
        }
        public async Task<CarModel> GetOneCarAsync(int id)
        { 

            var data=await _context.CarModel.Include(x=>x.Images).FirstOrDefaultAsync(x=>x.Id==id);
            //List<CarModel> cars = new List<CarModel>();
            //cars.Add(data);
            if (data == null || data.Active == false)
            {
                throw new Exception("carmodel not found");
            }
            return data;
        }
        public async Task<PagedList<CarModel>> GetcarbyCompnay(String name, int page = 1, int pageSize = 5)
        {
            var data = _context.CarModel.Where(x => x.CompanyMaster.companyAdminUsername == name).AsQueryable();
            var count = await data.LongCountAsync();
            var pagedList = data.ToPagedList(page, pageSize, count);

            return pagedList;
        }
        //public async Task<int> AddCarModel(CarModel carModel)
        //{ 

        //    _context.CarModel.Add(carModel);
        //    await _context.SaveChangesAsync();  
        //    return carModel.Id;
        //}
        public async Task<int> AddCarModel(CarModel carModel)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.CarModel.Add(carModel);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return carModel.Id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }

        //public async Task<int> UpdateCarModel(CarModel car)
        //{
        //    _context.CarModel.Update(car);
        //    await _context.SaveChangesAsync();
        //    return car.Id;
        //}
        public async Task<int> UpdateCarModel(CarModel car)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.CarModel.Update(car);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return car.Id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }
        
        //public async Task<int> DeleteCarModel(int id)
        //{
        //    var data = await _context.CarModel.FirstOrDefaultAsync(x => x.Id == id);

        //    data.Active = false;
        //    _context.CarModel.Update(data);
        //    await _context.SaveChangesAsync();
        //    return id;
        //}
        public async Task<int> DeleteCarModel(int id)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var data = await _context.CarModel.FirstOrDefaultAsync(x => x.Id == id);

                        if (data != null)
                        {
                            data.Active = false;
                            _context.CarModel.Update(data);
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
}
