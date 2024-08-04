using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PhoneCase.ModelVal
{
    public class PriceVal : ValidationAttribute
    {
        private readonly string[] _valPrice;

        public PriceVal(string[] valPrice)
        {
            _valPrice = valPrice;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || _valPrice.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Price entered is not one of the verified options");
            }
        }
    }
}
