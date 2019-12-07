using System.ComponentModel.DataAnnotations;
using AllocateYourExperts.Models.ProjectDtos;

namespace AllocateYourExperts.Models.Validations.ProjectDtosValidations
{
    public class EndDateGreaterThanStartDateAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (ProjectForCreationDto)validationContext.ObjectInstance;


            if (project != null)
            {
                if (project.EndDate < project.StartDate)
                {
                    return new ValidationResult("End date has to be greater than start date");
                }
            }

            return ValidationResult.Success;
        }


    }
}
