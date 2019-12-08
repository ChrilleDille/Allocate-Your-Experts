using AllocateYourExperts.Models.ProjectDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllocateYourExperts.Models.Validations.ProjectDtosValidations
{
    public class EndDateGreaterThanTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (ProjectForCreationDto)validationContext.ObjectInstance;
            if (project != null)
            {
                // Do not allow this if the project is not complete 
                //only allow if you want to change the time on a 
                //completed project later in the time during an update
                if (!project.IsCompleted)
                {
                    if (project.EndDate < DateTime.Today)
                    {
                        return new ValidationResult("End date has to be greater than todays date");
                    }
                }

            }

            return ValidationResult.Success;
        }
    }
}
