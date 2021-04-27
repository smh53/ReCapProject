using Core.Utilities.Results;
using Entities.DTOs;
using Entities.Rental;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);

        IDataResult<List<RentalDetailsDto>> GetAllRentalDetails();

        IResult Add(Rental rental);

        IResult Delete(int rentalId);
        IResult Update(Rental rental);

        IResult AddTransactionalTest(Rental rental);
    }
}
