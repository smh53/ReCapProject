using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Car;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))] // Bu validatoru kullanarak add metodunu validate et
        [CacheRemoveAspect("ICarService.GetAll")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [CacheRemoveAspect("ICarService.GetAllCarDetails")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [TransactionScopeAspect]
      
        public IResult Add(Car car, IFormFile[] files)
        {
            var entity = new Car()
            {
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear,
                Name = car.Name,
                CarImages = new List<CarImage>(),
            };
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(files.Count()));
            if (result != null)
            {
                return result;
            }

            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    Guid randomName = Guid.NewGuid();
                    string fileType = Path.GetExtension(file.FileName);
                    var fileName = String.Concat(randomName, fileType, "_", DateTime.Now.Day, "-", DateTime.Now.Month, "-", DateTime.Now.Year);
                    var saveDirectory = Path.Combine("CarImages", fileName);

                    entity.CarImages.Add(new CarImage { ImageName = fileName, ImagePath = saveDirectory, ImageType = fileType });
                    var stream = new FileStream(saveDirectory, FileMode.Create);
                    file.CopyTo(stream);
                }
            }

            _carDal.Add(entity);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int imageCount)
        {
            if (imageCount > 5)
                return new ErrorResult(Messages.CarImageLimitReached);
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("ICarService.GetAll")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [CacheRemoveAspect("ICarService.GetAllCarDetails")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        public IResult Delete(int carId)
        {
            var result = _carDal.Get(f => f.Id == carId);
            if (result != null)
            {
                _carDal.Delete(result);
                return new SuccessResult("Araba Silindi.");
            }
            return new ErrorResult("Böyle bir kayıt zaten yok");
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();

            return new SuccessDataResult<List<Car>>(result);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            
            var result = _carDal.GetAllCarDetails();
            if (result != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>("Hiçbir kayıt bulunamadı");
        }

        public IDataResult<Car> GetById(int carId)
        {
            var result = _carDal.Get(f => f.Id == carId);
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(f => f.BrandId == brandId);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(f => f.ColorId == colorId);
            return new SuccessDataResult<List<Car>>(result);
        }

        [CacheRemoveAspect("ICarService.GetAll")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [CacheRemoveAspect("ICarService.GetAllCarDetails")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        public IResult Update(Car car)
        {
            var result = _carDal.Get(f => f.Id == car.Id);
            if (result != null)
            {
                result.ModelYear = car.ModelYear;
                result.DailyPrice = car.DailyPrice;
                result.Description = car.Description;
                result.BrandId = car.BrandId;
                result.ColorId = car.ColorId;
                result.Name = car.Name;

                _carDal.Update(result);
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorResult("Böyle bir kayıt yok.");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            var result = _carDal.GetCarDetailsById(carId);

            if (result != null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailDto>>("Hiçbir kayıt bulunamadı");
        }

        public IDataResult<CarImage> GetCarImageById(int carImageId)
        {
            var result = _carDal.GetCarImageById(carImageId);
            return new SuccessDataResult<CarImage>(result.Data);
        }
        [CacheRemoveAspect("ICarService.GetAll")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [CacheRemoveAspect("ICarService.GetAllCarDetails")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        public IDataResult<Car> UpdateCarImage(CarImage carimage, IFormFile file)
        {

            var result = _carDal.GetCarAndCarImageByCarId(carimage.CarId).Data;
            if (file != null && file.Length > 0)
            {
                Guid randomName = Guid.NewGuid();
                string fileType = Path.GetExtension(file.FileName);
                var fileName = String.Concat(randomName, fileType, "_", DateTime.Now.Day, "-", DateTime.Now.Month, "-", DateTime.Now.Year);
                var saveDirectory = Path.Combine("CarImages", fileName);

                var stream = new FileStream(saveDirectory, FileMode.Create);
                file.CopyTo(stream);


                foreach (var item in result.CarImages)
                {
                    if (item.Id == carimage.Id)
                    {
                        item.ImageName = fileName;
                        item.ImagePath = saveDirectory;
                        item.ImageType = fileType;
                    }
                }         
            }
            _carDal.Update(result);
            return new SuccessDataResult<Car>(result);           
        }
        [CacheRemoveAspect("ICarService.GetAll")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        [CacheRemoveAspect("ICarService.GetAllCarDetails")] // add veya update yaptığımız zaman get metodlarındaki cacheleri silmeliyiz
        public IResult DeleteCarImage(int carimageId)
        {
            _carDal.DeleteCarImage(carimageId);
            
            return new SuccessResult("Deleted");
        }

      
    }
}