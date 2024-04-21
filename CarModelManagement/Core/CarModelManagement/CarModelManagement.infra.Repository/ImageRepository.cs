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
namespace CarModelManagement.infra.Repository
{
    public class ImageRepository: IImageRepository
    {
        readonly CarModelContext _context;
        public ImageRepository(CarModelContext context)
        {
            _context = context;
        }
        public async Task<int> AddImageModel(ImageModel comp)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            
                    try
                    {
                        string relativePath = $"/{Guid.NewGuid()}.jpg";
                        string imagePath = Path.Combine("wwwroot", relativePath.TrimStart('/'));

                        // Save the file to the server
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await comp.FormFile.CopyToAsync(stream);
                        }

                        // Save image information to database
                        comp.Path = relativePath; 
                        _context.ImageModel.Add(comp);
                        await _context.SaveChangesAsync();

                        // Commit the transaction
                        //await transaction.CommitAsync();

                        // Return the ID of the uploaded image
                        return comp.Id;
                    }
                    catch (Exception)
                    {
                        // Rollback the transaction in case of an error
                        //await transaction.RollbackAsync();
                        throw new BadRequestException("Transaction error. Please try again later.");
                    }
                

            //});
        }
        public async Task<List<ImageModel>> getallimagebycarid(int id)
        {
            var data = await _context.ImageModel.Where(x => x.CarModelId == id && x.Active).ToListAsync();
            return data;
        }
        public async Task<int> UpdateImageModel(ImageModel img)
        {
            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        _context.ImageModel.Update(img);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return img.Id;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw new BadRequestException("transaction error try another time");
                    }
                }
            });
        }
        public async Task<ImageModel> GetOneImageBycar(int id)
        {
            var data = _context.ImageModel.Where(x => x.CarModelId == id && x.Active).FirstOrDefault();
            if (data!=null)
            {
                return data;
            }
            var data1 = new ImageModel()
            {
                Id = 0,
                Path= "C:\\Users\\user\\Downloads\\stefan-rodriguez-2AovfzYV3rc-unsplash.jpg",
                CarModelId=id
            };
            return data1;
        }
        //private void SaveImageToFolder( ImageModel comp)
        //{
        //    //// Specify your project folder path
        //    //string projectFolder = "C:\\Users\\user\\source\\repos\\CarModelManagement\\CarModelManagement\\Core\\CarModelManagement\\CarModelManagement\\wwwroot\\";

        //    //// Create a folder based on CarModelId within your project folder
        //    //string carModelFolder = Path.Combine(projectFolder, comp.CarModelId.ToString());
        //    //Directory.CreateDirectory(carModelFolder);

        //    //// Save the image to the folder with a unique filename
        //    //string imagePath = Path.Combine(carModelFolder, $"{comp.Id}.jpg");


        //    //// Read the image bytes from the sourceImagePath
        //    //byte[] imageBytes = File.ReadAllBytes(comp.Path);
        //    //comp.Path = imagePath;
        //    //// Save the image to the specified folder
        //    //File.WriteAllBytes(imagePath, imageBytes);

        //}
        public string SaveImageToFolder(ImageModel comp)
        {
            // Specify the relative path for images in the wwwroot folder
            string relativePath = $"/{comp.CarModelId}/{Guid.NewGuid()}.jpg";

            // Construct the full image path within the wwwroot folder
            string imagePath = Path.Combine("wwwroot", relativePath.TrimStart('/'));

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

            // Copy the image file to the specified path
            File.Copy(comp.Path, imagePath);

            // Update the ImageModel path with the relative path
            comp.Path = relativePath;
            return relativePath;
        }

    }
}
