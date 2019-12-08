using AllocateYourExperts.Models.Validations.ExpertDtosValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AllocateYourExperts.Models.ExpertDtos
{
    public class ExpertForCreationDto
    {
        [Required]
        [RegularExpression(@"^\p{Lu}\p{Ll}*$", ErrorMessage = "Name starts with a capital letter followed by lowercase letters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [EmailUnique]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
