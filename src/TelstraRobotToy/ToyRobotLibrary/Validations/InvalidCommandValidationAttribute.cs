using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotLibrary
{
    public class InvalidCommandValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value is null || value.GetType() == typeof(UnrecognizedCommand))
                return new ValidationResult(ErrorMessage ?? 
                    ROBOTRESPONSE.INVALID_COMMAND_RESPONSE);
            return ValidationResult.Success;
        }
    }
}
