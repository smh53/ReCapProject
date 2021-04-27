using Entities.Car;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).MinimumLength(2).WithMessage("Araba ismi en az 2 karakter uzunluğunda olmalı!");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Araba günlük fiyat 0 dan büyük olmalıdır!");
            //RuleFor(c => c.CarImages.Count).LessThan(5).WithMessage("Bir araba için en fazla 5 adet resim yüklenebilir!");
        }
    }
}
