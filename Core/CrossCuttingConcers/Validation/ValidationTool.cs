using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Validation
{
    public static class ValidationTool 
    {
        //static nesneler program derlenirken 1 tane instance oluşturur ve hep onu kullanır.
        // Çağırıldığı ilk yerde direk olarak newlenir zaten unutma!!.
        public static void Validate(IValidator validator, object entity)
        {
            
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            //var context = new ValidationContext<User>(user);
            //UserValidator userValidation = new UserValidator();
            //var result = userValidation.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

        }
    }
}
