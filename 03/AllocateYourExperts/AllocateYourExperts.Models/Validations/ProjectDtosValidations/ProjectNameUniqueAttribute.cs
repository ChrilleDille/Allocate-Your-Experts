using AllocateYourExperts.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AllocateYourExperts.Models.Validations.ProjectDtosValidations
{
    public class ProjectNameUniqueAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var context = (AYEDbContext)validationContext.GetService(typeof(AYEDbContext));
            var project = context.Projects.SingleOrDefault(p => p.Name == value.ToString());
            if (project != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(string projectName)
        {
            return $"A project named {projectName} already exists";
        }
    }

}


