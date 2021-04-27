﻿using Core.Utilities.Results;
using Entities.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);

        IResult Add(Brand brand);

        IResult Delete(int brandId);
        IResult Update(Brand brand);

        IResult AddTransactionalTest(Brand brand);
    }
}