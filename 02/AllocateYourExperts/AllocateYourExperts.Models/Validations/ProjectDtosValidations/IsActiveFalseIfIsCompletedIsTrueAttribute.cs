using AllocateYourExperts.Models.ProjectDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllocateYourExperts.Models.Validations.ProjectDtosValidations
{
    public class IsActiveTrueAndIsCompletedTrueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext) 
        {
            var project = (ProjectForCreationDto)validationContext.ObjectInstance;
            if (project != null) 
            {
                if (project.IsActive && project.IsCompleted) 
                {
                    return new ValidationResult("A completed project cannot be active");
                }
            }

            return ValidationResult.Success;
        }

        
    }
}
