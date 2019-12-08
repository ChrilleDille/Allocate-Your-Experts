using AllocateYourExperts.Models.Validations.ProjectDtosValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AllocateYourExperts.Models.ProjectDtos
{
    public class ProjectForCreationDto
    {
        [Required]
        [MaxLength(50)]
        [ProjectNameUnique]
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        [EndDateGreaterThanToday]
        [EndDateGreaterThanStartDate]
        public DateTime? EndDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [IsActiveTrueAndIsCompletedTrue]
        public bool IsCompleted { get; set; }

    }
}
