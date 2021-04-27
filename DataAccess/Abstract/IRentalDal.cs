using Core.DataAccess;
using DataAccess.Concrete.Context;
using Entities.DTOs;
using Entities.Rental;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetAllRentalDetails();
    }
}