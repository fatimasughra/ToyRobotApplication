using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
    public class RobotNotPlacedValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not null &&
                (value.GetType() != typeof(UnrecognizedCommand) 
                && value.GetType().GetInterfaces().Any(e=>e == typeof(IPlaceableCommand))==false))
            {
                var command = ((ICommand)value);
                if (command.CurrentRobotContext.CurrentPosition.Direction == DIRECTION.NODIRECTION)
                {
                    return new ValidationResult(ErrorMessage ?? ROBOTRESPONSE.ROBOT_NOT_PLACED_RESPONSE);
                }
            }
            return ValidationResult.Success;

        }
    }
}
