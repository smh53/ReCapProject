using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfBrandDal : EfEntityRepositoryBase<Brand, ReCapContext>, IBrandDal
    {
    }
}
