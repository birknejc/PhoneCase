using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PhoneCase.ModelVal
{
    public class ColorVal : ValidationAttribute
    {
        private readonly string[] _valColor;

        public ColorVal(string[] valColor)
        {
            _valColor = valColor;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || _valColor.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Color entered is not one of the verified options");
            }
        }
    }
}
