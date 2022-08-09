using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC.Webcam.js.Test.Tools.Helpers
{
    public static class ValidateModelHelper
    {
        public static List<ValidationResult> ValidateModelWithAnotations(object model)
        {
            var validationResult = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResult, true);
            return validationResult;
        }
    }
}