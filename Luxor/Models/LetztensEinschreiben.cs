using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Luxor.Models
{
    public class LetztensEinschreiben: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var std = (Student) validationContext.ObjectInstance;
            if (std.Einschreibung == null)
            {
                return new ValidationResult("Einschreibung ist erforderlich");
            }
            else
            {
                var age = DateTime.Today.Year - std.Einschreibung.Year;
                if (age > 3)
                {
                    return new ValidationResult(" Nur in der letzter Zeit ist erlaubt");
                }
                return ValidationResult.Success;
            
            }
        }
    }
}