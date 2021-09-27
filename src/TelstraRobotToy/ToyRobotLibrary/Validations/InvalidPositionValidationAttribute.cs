using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ToyRobotLibrary.Interfaces;

namespace ToyRobotLibrary
{
    class InvalidPositionValidationAttribute: ValidationAttribute
    {

        protected override ValidationResult IsValid
                  (object value, ValidationContext validationContext)
        {

            if (value is not null)
            {
                var command = (ICommand)value;
                if (command.GetType().GetInterfaces().Any(e => e == typeof(IPositionChangingCommand)))
                {
                    
                    var newPosition = command.NewPositionInstruction;

                    string errorMessage = ROBOTRESPONSE.INVALID_POISITION_RESPONSE;


                    if (newPosition.X < 0 || newPosition.X >= RobotPosition.MAX_X)
                    {
                        ErrorMessage = ErrorMessage ?? errorMessage;
                        return new ValidationResult(ErrorMessage);
                    }

                    if (newPosition.Y < 0 || newPosition.Y >= RobotPosition.MAX_Y)
                    {
                        ErrorMessage = ErrorMessage ?? errorMessage;
                        return new ValidationResult(ErrorMessage);
                    }

                    if(newPosition.Direction == DIRECTION.NODIRECTION)
                    {
                        ErrorMessage = ErrorMessage ?? ROBOTRESPONSE.INVALID_DIRECTION_RESPONSE;
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
