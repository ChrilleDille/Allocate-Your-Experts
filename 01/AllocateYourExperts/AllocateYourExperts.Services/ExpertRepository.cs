using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ExpertProjectsDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllocateYourExperts.Services
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AYEDbContext context;

        public ExpertRepository(AYEDbContext context)
        {
            this.context = context;
        }

        //-----------------------------------------------------------------------------
        public IEnumerable<Expert> GetExperts()
        {
            return context.Experts;
        }

        public bool ExpertExist(Guid expertId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            return context.Experts.Any(e => e.Id == expertId);
        }

        public Expert GetExpert(Guid expertId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            return context.Experts.FirstOrDefault(e => e.Id == expertId);
        }

        public void CreateExpert(Expert expert)
        {
            if (expert == null)
            {
                throw new ArgumentNullException(nameof(expert));
            }

            expert.Id = Guid.NewGuid();
            context.Experts.Add(expert);
        }

        public void UpdateExpert(Guid expertId, Expert expert)
        {
            if (expert == null)
            {
                throw new ArgumentNullException(nameof(expert));
            }
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var expertToUpdate = this.GetExpert(expertId);
            expertToUpdate.Name = expert.Name;
            expertToUpdate.Email = expert.Email;
        }

        public void DeleteExpert(Guid expertId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var expertToDelete = this.GetExpert(expertId);
            context.Experts.Remove(expertToDelete);
        }

        //-----------------------------------------------------------------------------
        public IEnumerable<Expert> GetExpertsIncludedProjectsAndRoles()
        {
            var experts = context.Experts
                .Include(e => e.ExpertProjects)
                .ThenInclude(ep => ep.Project)
                .Include(e => e.ExpertProjects)
                .ThenInclude(ep => ep.Role);
               
            return experts;
        }

        public Expert GetExpertIncludedProjectsAndRoles(Guid expertId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var expert = this.GetExpertsIncludedProjectsAndRoles()
                .FirstOrDefault(e => e.Id == expertId);
            return expert;
        }

        public bool ProjectIsAssociatedWithExpert(Guid expertId, Guid projectId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }
            if (projectId == Guid.Empty) 
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            return this.GetExpertIncludedProjectsAndRoles(expertId)
                .ExpertProjects
                .Any(ep => ep.ProjectId == projectId);

        }

        public void RemoveProjectsFromExpert(Guid expertId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var expertProjectsToRemove = this.GetExpertIncludedProjectsAndRoles(expertId)
                .ExpertProjects;
            context.RemoveRange(expertProjectsToRemove);
        }

        public void AddExpertProject(Guid expertId, Guid projectId) 
        {
            this.GetExpert(expertId).ExpertProjects.Add(
                new ProjectExpertRole
                {
                    ProjectId = projectId,
                    RoleId = Guid.Parse("c0aa725f-3804-4fe9-a51f-74c3e7780475") // Member hard coded for now 
                }
                );
        }

        public void RemoveProjectFromExpert(Guid expertId, Guid projectId)
        {
            if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var expertProject = this.GetExpertIncludedProjectsAndRoles(expertId)
                .ExpertProjects.FirstOrDefault(ep => ep.ProjectId == projectId);
            context.Remove(expertProject);
        }

        public ExpertWithProjects GetExpertWithProjectsMap(Guid expertId)
        {
            var expertWithProjects = new ExpertWithProjects();
            expertWithProjects.Expert = this.GetExpert(expertId);
            expertWithProjects.ProjectsAndRoles = new List<ProjectAndRole>();
            foreach (var ewp in
                this.GetExpertIncludedProjectsAndRoles(expertId)
                .ExpertProjects)
            {
                expertWithProjects.ProjectsAndRoles.Add(new ProjectAndRole
                {
                    Project = ewp.Project,
                    Role = ewp.Role
                });
            }

            return expertWithProjects;
        }
        //-----------------------------------------------------------------------------


        //-----------------------------------------------------------------------------
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
