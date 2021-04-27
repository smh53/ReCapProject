using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Car;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id

                             select new CarDetailDto
                             {
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 CarImages = c.CarImages.ToList()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                string path = "/CarImages/logo.png";
                var defaultImage = new List<CarImage>();

                defaultImage.Add(new CarImage { ImageName = "logo.png", ImagePath = path, ImageType = ".png", CarId = carId });
                var result = from car in context.Cars

                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.Id == carId
                             select new CarDetailDto
                             {
                                 CarName = car.Name,
                                 CarImages = car.CarImages.Count == 0 ? defaultImage : car.CarImages.ToList(), // arabanın resmi yoksa default resim göster
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                             };

                return result.ToList();
            }
        }

        public IDataResult<CarImage> GetCarImageById(int carImageId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.CarImages.Find(carImageId);
                return new SuccessDataResult<CarImage>(result);
            }
        }

        public IDataResult<Car> GetCarAndCarImageByCarId(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var carEntity = context.Cars.Include(p => p.CarImages).Where(f => f.Id == carId).FirstOrDefault();

                return new SuccessDataResult<Car>(carEntity);
            }
        }

        public IResult DeleteCarImage(int carimageId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var row = context.CarImages.Find(carimageId);
                context.CarImages.Remove(row);
                context.SaveChanges();
                             
               
                return new SuccessResult();
                
            }
        }
    }
}