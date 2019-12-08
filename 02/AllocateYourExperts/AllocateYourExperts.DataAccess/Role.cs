using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AllocateYourExperts.DataAccess
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public ICollection<ProjectExpertRole> ProjectExpertRoles { get; set; }
        = new List<ProjectExpertRole>();
    }
}
