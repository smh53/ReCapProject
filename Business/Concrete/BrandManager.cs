using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Brand brand)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int brandId)
        {
            var result = _brandDal.Get(f => f.Id == brandId);
            if(result != null)
            {
                _brandDal.Delete(result);
                return new SuccessResult("Marka silindi.");
            }
            return new ErrorResult("Böyle bir kayıt zaten yok.");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            return new SuccessDataResult<List<Brand>>(result);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(f => f.Id == brandId);
            if(result != null)
            {
                return new SuccessDataResult<Brand>(result);
            }
            return new ErrorDataResult<Brand>(result, "Bulunamadı.");
        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(f => f.Id == brand.Id);

            if(result!= null)
            {
                result.Name = brand.Name;
                _brandDal.Update(result);
                return new SuccessResult("Marka Güncellendi.");
            }
            return new ErrorResult("Böyle bir kayıt  yok.");
        }
    }
}
