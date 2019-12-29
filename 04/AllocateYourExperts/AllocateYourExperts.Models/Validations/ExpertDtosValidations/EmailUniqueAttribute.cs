using AllocateYourExperts.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AllocateYourExperts.Models.Validations.ExpertDtosValidations
{
    public class EmailUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext) 
        {
            var context = (AYEDbContext)validationContext.GetService(typeof(AYEDbContext));
            var expert = context.Experts.FirstOrDefault(e => e.Email == value.ToString());

            if (expert != null)
            {
                return new ValidationResult($"Email address: {value.ToString()} already exists");
            }

            return ValidationResult.Success;
        }

        
    }
}
