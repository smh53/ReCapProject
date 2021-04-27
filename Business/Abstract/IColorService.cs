using Core.Utilities.Results;
using Entities.Color;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);

        IResult Add(Color color);

        IResult Delete(int colorId);
        IResult Update(Color color);

        IResult AddTransactionalTest(Color color);
    }
}
