using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PhoneCase.ModelVal
{
    public class MaterialVal : ValidationAttribute
    {
        private readonly string[] _valMaterial;

        public MaterialVal(string[] valMaterial)
        {
            _valMaterial = valMaterial;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || _valMaterial.Contains(value.ToString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The material entered is not one of the verified options");
            }
        }
    }
}