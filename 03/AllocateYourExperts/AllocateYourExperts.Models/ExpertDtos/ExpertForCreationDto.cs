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
        [MaxLength(50)]
        [RegularExpression(@"^\p{Lu}\p{Ll}*$", ErrorMessage = "Name starts with a capital letter followed by lowercase letters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^\p{Lu}\p{Ll}*$", ErrorMessage = "Name starts with a capital letter followed by lowercase letters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [EmailUnique]
        public string Email { get; set; }

        [Required]
        [MaleOrFemale]
        public string Gender { get; set; }
    }
}
