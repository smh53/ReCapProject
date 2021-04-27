using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Color;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin,color.add")]

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int colorId)
        {
            var result = _colorDal.Get(f => f.Id == colorId);
            if (result != null)
            {
                _colorDal.Delete(result);
                return new SuccessResult("Renk Silindi.");
            }
            return new ErrorResult("Böyle bir kayıt zaten yok");
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(f => f.Id == colorId);
            if (result != null)
            {
                return new SuccessDataResult<Color>(result);
            }
            return new ErrorDataResult<Color>(result, "Bulunamadı.");
        }

        public IResult Update(Color color)
        {
            var result = _colorDal.Get(f => f.Id == color.Id);
            if (result != null)
            {
                result.Name = color.Name;
                _colorDal.Update(color);
                return new SuccessResult("Renk güncellendi.");
            }
            return new ErrorResult("Böyle bir kayıt yok.");
        }
    }
}