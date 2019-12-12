using AllocateYourExperts.Models.ExpertDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllocateYourExperts.Models.Validations.ExpertDtosValidations
{
    public class MaleOrFemaleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var expert = (ExpertForCreationDto)validationContext.ObjectInstance;

            if (!(expert.Gender == "Male" || expert.Gender == "Female"))
            {
                return new ValidationResult("Gender is either male or female");
            }


            return ValidationResult.Success;
        }
    }
}
