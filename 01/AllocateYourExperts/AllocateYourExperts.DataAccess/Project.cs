using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AllocateYourExperts.DataAccess
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
       
        [JsonIgnore]
        public ICollection<ProjectExpertRole> ProjectExperts { get; set; }
        = new List<ProjectExpertRole>();
    }
}
