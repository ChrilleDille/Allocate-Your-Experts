using AllocateYourExperts.Models.ExpertProjectsDtos;
using AllocateYourExperts.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocateYourExperts.API.Controllers
{
    [ApiController]
    [Route("api/experts/{expertId}/expertprojects")]
    public class ExpertProjectsController : ControllerBase
    {
        private readonly IExpertRepository expertRepository;
        private readonly IMapper mapper;

        public ExpertProjectsController(IExpertRepository expertRepository,
            IMapper mapper)
        {
            this.expertRepository = expertRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetExpertProjects")]
        public ActionResult<ExpertWithProjects> GetExpertProjects(Guid expertId)
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            var expertWithProjects = expertRepository.GetExpertWithProjectsMap(expertId);
            return Ok(expertWithProjects);
        }

        [HttpGet("{projectId}", Name = "GetExpertProject")]
        public ActionResult<ProjectAndRole> GetExpertProject(Guid expertId,
            Guid projectId)
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            if (!expertRepository
                .ProjectIsAssociatedWithExpert(expertId, projectId))
            {
                return NotFound($"The project you are trying to reach has no connection to " +
                    $"{expertRepository.GetExpert(expertId).Name}");
            }

            var projectAndRole = expertRepository.GetExpertWithProjectsMap(expertId)
                 .ProjectsAndRoles.FirstOrDefault(par => par.Project.Id == projectId);
            return Ok(projectAndRole);
        }

        [HttpPost]
        public ActionResult<ProjectAndRole> AddExistingProjectToExpert(Guid expertId,
            ProjectAndRole projectAndRole)
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            var expert = expertRepository.GetExpertIncludedProjectsAndRoles(expertId);

            if (expertRepository
                .ProjectIsAssociatedWithExpert(expert.Id, projectAndRole.Project.Id))
            {
                var expertProject = expert.ExpertProjects
                    .FirstOrDefault(ep => ep.ProjectId == projectAndRole.Project.Id);
                return Conflict($"{expertProject.Project.Name} is already associated with {expertProject.Expert.Name}");
            }

            expertRepository.AddExpertProject(expert.Id, projectAndRole.Project.Id);
            expertRepository.Save();

            var projectAndRoleToReturn = expertRepository.GetExpertWithProjectsMap(expertId)
                 .ProjectsAndRoles.FirstOrDefault(par => par.Project.Id == projectAndRole.Project.Id);
            return CreatedAtRoute("GetExpertProject", new
            {
                expertId = expert.Id,
                projectId = projectAndRoleToReturn.Project.Id
            },
            projectAndRoleToReturn);
        }

        [HttpDelete("{projectId}")]
        public ActionResult RemoveProjectFromExpert(Guid expertId, Guid projectId)
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            if (!expertRepository.ProjectIsAssociatedWithExpert(expertId, projectId))
            {
                return NotFound();
            }

            expertRepository.RemoveProjectFromExpert(expertId, projectId);
            expertRepository.Save();
            return NoContent();
        }

    }
}
