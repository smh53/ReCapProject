using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspectAttribute : MethodInterceptionAttribute
    {
        private Type _validatorType;
        public ValidationAspectAttribute(Type validatorType)
        {
          
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir validasyoncu değil!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //DogValidator tipinde IValidator nesnesi oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Dogvalidatorun miras aldığı classı bul, T'sini al (Dog)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // İlgili methodun parametrelerini bul (Dog) tipi (Dog) olanları al
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}