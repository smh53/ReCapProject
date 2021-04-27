using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Color;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfColorDal : EfEntityRepositoryBase<Color,ReCapContext>, IColorDal
    {
    }
}
