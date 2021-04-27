using Core.DataAccess;
using Entities.Color;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public  interface IColorDal : IEntityRepository<Color>
    {
    }
}
