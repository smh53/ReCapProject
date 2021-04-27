using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            IResult result = BusinessRules.Run(IsRented(rental));
            if (result != null)
            {
                return result;
            }
           
          
            _rentalDal.Add(rental);
            return new SuccessResult();

        }

        private IResult IsRented(Rental rental)
        {
            var isRented = _rentalDal.GetAll(f => f.CarId == rental.CarId).LastOrDefault();
            
            if (isRented != null)
            { 
            
            if (isRented.ReturnDate == null)
            {
                return new ErrorResult(Messages.AlreadyRented);
            }
            return new SuccessResult();
            }
           
                return new SuccessResult();
           
        }

        public IResult AddTransactionalTest(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int rentalId)
        {
            var result = _rentalDal.Get(f => f.Id == rentalId);
            if(result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotFound);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Rental>>(result);
            }
            return new ErrorDataResult<List<Rental>>(Messages.NotFound);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var result = _rentalDal.Get(f => f.Id == rentalId);

            if(result != null)
            {
                return new SuccessDataResult<Rental>(result);
            }
            return new ErrorDataResult<Rental>(Messages.NotFound);
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(f => f.Id == rental.Id);

            if (result != null)
            {
                result.RentDate = rental.RentDate;
                result.ReturnDate = rental.ReturnDate;
                result.CustomerId = rental.CustomerId;
                result.CarId = rental.CarId;

                _rentalDal.Update(result);
                return new SuccessDataResult<Rental>(result);
            }
            return new ErrorDataResult<Rental>(Messages.NotFound);
        }

        public IDataResult<List<RentalDetailsDto>> GetAllRentalDetails()
        {
            var result = _rentalDal.GetAllRentalDetails();
            return new SuccessDataResult<List<RentalDetailsDto>>(result);
        }
    }
}
