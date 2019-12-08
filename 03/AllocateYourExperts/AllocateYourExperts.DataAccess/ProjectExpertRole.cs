using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.DataAccess
{
    public class ProjectExpertRole
    {
        public Guid ExpertId { get; set; }
        public Expert Expert { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
