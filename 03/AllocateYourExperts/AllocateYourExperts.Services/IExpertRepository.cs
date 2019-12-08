using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ExpertProjectsDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Services
{
    public interface IExpertRepository
    {
        //----------------------------------------------------
        IEnumerable<Expert> GetExperts();
        Expert GetExpert(Guid expertId);
        bool ExpertExist(Guid expertId);
        void CreateExpert(Expert expert);
        void UpdateExpert(Guid expertId, Expert expert);
        void DeleteExpert(Guid expertId);
        //----------------------------------------------------

        //----------------------------------------------------
        IEnumerable<Expert> GetExpertsIncludedProjectsAndRoles();
        Expert GetExpertIncludedProjectsAndRoles(Guid expertId);
        ExpertWithProjects GetExpertWithProjectsMap(Guid expertId);
        void RemoveProjectsFromExpert(Guid expertId);
        void AddExpertProject(Guid expertId, Guid projectId);
        bool ProjectIsAssociatedWithExpert(Guid expertId, Guid projectId);
        void RemoveProjectFromExpert(Guid expertId, Guid projectId);
        //----------------------------------------------------
        void Save();
    }
}
