using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToyRobotLibrary
{
    public class ValidatorHelper
    {
        public static IEnumerable<ValidationResult> Validate(object obj)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
            return results;
        }
    }
}
