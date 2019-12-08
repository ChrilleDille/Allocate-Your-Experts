using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.Validations.ExpertDtosValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AllocateYourExperts.Models.ExpertDtos
{
    public class ExpertDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
    }
}
