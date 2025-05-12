using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public static class ValidationHelper
    {
        public static bool Validate<T>(T t)
        {
            try
            {
                Validator.ValidateObject(t, new ValidationContext(t), true);
                return true;
            }
            catch(ValidationException ex)
            {
                //Log.LogError(ex.Message);
                return false;
            }
        }
    }
}
