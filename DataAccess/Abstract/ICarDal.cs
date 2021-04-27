using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Car;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails();
        List<CarDetailDto> GetCarDetailsById(int carId);
     
        IDataResult<CarImage> GetCarImageById(int carImageId);


        IDataResult<Car> GetCarAndCarImageByCarId(int carId);
        IResult DeleteCarImage(int carimageId);
    }
}
