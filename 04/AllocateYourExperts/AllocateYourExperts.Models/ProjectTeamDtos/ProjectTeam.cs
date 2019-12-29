using AllocateYourExperts.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AllocateYourExperts.Models.ProjectTeamDtos
{
    public class ProjectTeam
    {
        public Project Project { get; set; }  
        public List<TeamMember> Members { get; set; }

    }
}
