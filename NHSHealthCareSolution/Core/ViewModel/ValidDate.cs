
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NHSHealthCareSolution.Core.ViewModel
{
    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            ValidationResult validationResult = isValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);

            return validationResult;
        }
    }
}