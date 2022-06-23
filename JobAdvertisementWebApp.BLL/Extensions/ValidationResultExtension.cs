using FluentValidation.Results;
using JobAdvertisementWebApp.Common.ResponseObjects;
using System.Collections.Generic;

namespace JobAdvertisementWebApp.BLL.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = error.ErrorMessage,
                    PropertyName = error.PropertyName
                }); 
            }
            return errors;
        }
    }
}
