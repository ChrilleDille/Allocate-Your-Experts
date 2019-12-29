using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AllocateYourExperts.DataAccess
{
    public class Expert
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
       
        [JsonIgnore]
        public ICollection<ProjectExpertRole> ExpertProjects { get; set; }
        = new List<ProjectExpertRole>();
    }
}
