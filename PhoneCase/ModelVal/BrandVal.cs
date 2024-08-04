using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PhoneCase.ModelVal
{
    public class BrandVal : ValidationAttribute
    {
        private readonly string[] _valBrand;

        public BrandVal(string[] valBrand)
        {
            _valBrand = valBrand;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || _valBrand.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The brand entered is not one of the verified options");
            }
        }
    }
}
