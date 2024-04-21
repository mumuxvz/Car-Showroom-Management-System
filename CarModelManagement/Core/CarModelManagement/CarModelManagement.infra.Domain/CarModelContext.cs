using CarModelManagement.infra.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModelManagement.infra.Domain
{
    public class CarModelContext : IdentityDbContext<IdentityUser>
    {
        public CarModelContext(DbContextOptions<CarModelContext> options)
           : base(options)
        {

        }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<ImageModel> ImageModel { get; set; }
        public DbSet<Companymaster> Companymaster { get; set; }
        public DbSet<HeaderMaster> headerMaster { get; set; }
        public DbSet<ItemMaster> itemmaster { get; set; }
        public DbSet<VehicleInverntory> vehicleInverntory { get; set; }

        public DbSet<Expanse> Expanse { get; set; }
        public DbSet<Overlapped> overhead { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasMany(car => car.Images)
                .WithOne(i => i.CarModel)
                .HasForeignKey(i => i.CarModelId);

            modelBuilder.Entity<CarModel>()
                .HasMany(car => car.itemMasters)
                .WithOne(i => i.CarModel)
                .HasForeignKey(i => i.carModelId);

            modelBuilder.Entity<CarModel>()
                .HasMany(car => car.VehicleInverntorys)
                .WithOne(i => i.CarModel)
                .HasForeignKey(i => i.VehicleId);

            modelBuilder.Entity<Companymaster>()
               .HasMany(c => c.HeaderMasters)
               .WithOne(h => h.CompanyMaster)
               .HasForeignKey(h => h.CompanyMasterID);

            modelBuilder.Entity<Companymaster>()
               .HasMany(c => c.CarModels)
               .WithOne(h => h.CompanyMaster)
               .HasForeignKey(h => h.CompanyMasterID);

            modelBuilder.Entity<HeaderMaster>()
                .HasMany(h => h.ItemMaster)
                .WithOne(i => i.HeaderMaster)
                .HasForeignKey(i => i.HeaderMasterID);

            modelBuilder.Entity<Companymaster>()
                .HasMany(c => c.Expanses)
                .WithOne(i => i.CompanyMaster)
                .HasForeignKey(i => i.CompanyMasterID);

            modelBuilder.Entity<Companymaster>()
                .HasMany(c => c.VehicleInverntories)
                .WithOne(i => i.CompanyMaster)
                .HasForeignKey(i => i.CompanyMasterID);


            modelBuilder.Entity<Overlapped>()
       .Ignore(o => o.AsyncResult)
       .HasNoKey();
            modelBuilder.Entity<Overlapped>()
        .Ignore(o => o.EventHandleIntPtr).HasNoKey();




            base.OnModelCreating(modelBuilder);
        }
       
    }
}
