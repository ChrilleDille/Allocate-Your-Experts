using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models;
using AllocateYourExperts.Models.ProjectTeamDtos;
using Microsoft.EntityFrameworkCore;

namespace AllocateYourExperts.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AYEDbContext context;

        public ProjectRepository(AYEDbContext context)
        {
            this.context = context;
        }

        //------------------------------------------------------------------------------------------------
        public IEnumerable<Project> GetProjects()
        {
            return context.Projects.OrderByDescending(p => p.EndDate);
        }

        public Project GetProject(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }
            return context.Projects.FirstOrDefault(p => p.Id == projectId);
        }

        public void CreateProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentException(nameof(project));
            }

            project.Id = Guid.NewGuid();
            context.Projects.Add(project);
        }

        public void UpdateProject(Guid projectId, Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException();
            }

            var projectToUpdate = this.GetProject(projectId);
            projectToUpdate.Name = project.Name;
            projectToUpdate.StartDate = project.StartDate;
            projectToUpdate.EndDate = project.EndDate;
            projectToUpdate.IsActive = project.IsActive;
        }

        public bool ProjectExist(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentException(nameof(projectId));
            }

            return context.Projects.Any(p => p.Id == projectId);
        }

        public void DeleteProject(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentException(nameof(projectId));
            }
            var project = this.GetProject(projectId);
            context.Projects.Remove(project);
        }
        //------------------------------------------------------------------------------------------------



        //------------------------------------------------------------------------------------------------
        public IEnumerable<Project> GetProjectsIncludedExpertsAndRoles()
        {
            var projects = context.Projects
                .Include(p => p.ProjectExperts)
                .ThenInclude(pe => pe.Expert)
                .Include(p => p.ProjectExperts)
                .ThenInclude(pe => pe.Role);

            return projects;
        }

        public Project GetProjectIncludedExpertsAndRoles(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }

            var project = this.GetProjectsIncludedExpertsAndRoles()
                .FirstOrDefault(p => p.Id == projectId);

            return project;
        }

       
        public bool ExpertBelongsToProject(Guid projectId, Guid expertId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }
            else if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            return this.GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts
                .Any(pe => pe.ExpertId == expertId);
        }

        public void RemoveProjectExperts(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }

            var projectExperts = this.GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts;
            context.RemoveRange(projectExperts);
        }

        public void RemoveExpertFromProject(Guid projectId, Guid expertId)
        {
            if (projectId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(projectId));
            }
            else if (expertId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(expertId));
            }

            var projectExpert = this.GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts.FirstOrDefault(pe => pe.ExpertId == expertId);
            context.Remove(projectExpert);
        }

        public bool ProjectAlreadyHaveOneLeader(Guid projectId)
        {
            return this.GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts.Any(pe => pe.Role.Name == "Leader");
        }
        public ProjectTeam GetProjecTeamMap(Guid projectId)
        {
            var projectTeamDto = new ProjectTeam();
            projectTeamDto.Project = this.GetProject(projectId);
            projectTeamDto.Members = new List<TeamMember>();
            foreach (var pe in 
                this.GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts)
            {
                projectTeamDto.Members.Add(new TeamMember { 
                Expert = pe.Expert,
                Role = pe.Role
                });
            }

            return projectTeamDto;
        }

        //------------------------------------------------------------------------------------------------
        public Role GetRoleAsMember() 
        {
            return context.Roles.FirstOrDefault(r => r.Name == "Member");
        }
        public Role GetRoleAsLeader() 
        {
            return context.Roles.FirstOrDefault(r => r.Name == "Leader");
        }
       
        public void AddProjectExpert(Guid projectId, Guid expertId, Guid roleId)
        {
            this.GetProject(projectId).ProjectExperts.Add(
                new ProjectExpertRole
                {
                    ExpertId = expertId,
                    RoleId = roleId
                }
                );
        }
        //------------------------------------------------------------------------------------------------

        public void Save()
        {
            context.SaveChanges();
        }

       
       
    }
}
