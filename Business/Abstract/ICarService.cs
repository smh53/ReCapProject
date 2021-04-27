using Core.Utilities.Results;
using Entities.Car;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);

        IResult Add(Car car, IFormFile[] files);

        IResult Delete(int carId);
        IResult DeleteCarImage(int carimageId);

        IDataResult<List<CarDetailDto>> GetAllCarDetails();
      

        IDataResult<CarImage> GetCarImageById(int carImageId);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IResult Update(Car car);
        IDataResult<Car> UpdateCarImage(CarImage carimage, IFormFile file );
        
        IResult AddTransactionalTest(Car car);
      
    }
}
