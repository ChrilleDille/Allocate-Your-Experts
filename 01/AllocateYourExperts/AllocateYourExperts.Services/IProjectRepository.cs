using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models;
using AllocateYourExperts.Models.ProjectTeamDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Services
{
    public interface IProjectRepository
    {
        //--------------------------------------------------
        IEnumerable<Project> GetProjects();
        Project GetProject(Guid projectId);
        bool ProjectExist(Guid projectId);
        void CreateProject(Project project);
        void UpdateProject(Guid projectId, Project project);
        void DeleteProject(Guid projectId);
        //--------------------------------------------------

        //--------------------------------------------------
        
        IEnumerable<Project> GetProjectsIncludedExpertsAndRoles();       
        Project GetProjectIncludedExpertsAndRoles(Guid projectId);
        ProjectTeam GetProjectTeamMap(Guid projectId); 
        void RemoveExpertFromProject(Guid projectId, Guid expertId);
        bool ExpertBelongsToProject(Guid projectId, Guid expertId);
        void RemoveProjectExperts(Guid projectId);
        bool ProjectAlreadyHaveOneLeader(Guid projectId);
        
        //--------------------------------------------------

        //--------------------------------------------------
        Role GetRoleAsMember();
        Role GetRoleAsLeader();
        void AddProjectExpert(Guid projectId, Guid expertId, Guid roleId );
        //--------------------------------------------------

        void Save();










    }
}
