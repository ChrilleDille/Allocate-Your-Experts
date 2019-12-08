using AllocateYourExperts.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Models.ExpertProjectsDtos
{
    public class ExpertWithProjects
    {
        public Expert Expert { get; set; }
        public List<ProjectAndRole> ProjectsAndRoles { get; set; }
    }
}
