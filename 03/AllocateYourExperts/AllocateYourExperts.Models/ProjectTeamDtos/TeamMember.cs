using AllocateYourExperts.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Models.ProjectTeamDtos
{
    public class TeamMember
    {
        public Expert Expert { get; set; }
        public Role Role { get; set; }
    }
}
