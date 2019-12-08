using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ProjectDtos;
using AllocateYourExperts.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllocateYourExperts.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectsController(IProjectRepository projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetProjects()
        {
            var projectsToReturn = mapper.Map<IEnumerable<ProjectDto>>
                (projectRepository.GetProjects());
            return Ok(projectsToReturn
                .OrderByDescending(p => p.IsActive)
                .ThenBy(p => p.EndDate));
        }

        [HttpGet("{projectId}", Name = "GetProject")]
        public ActionResult<ProjectDto> GetProject(Guid projectId)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            var projectToReturn = mapper.Map<ProjectDto>
                (projectRepository.GetProject(projectId));
            return Ok(projectToReturn);
        }

        [HttpPost]
        public ActionResult<ProjectDto> CreateProject(ProjectForCreationDto projectInput)
        {
            var projectToCreate = mapper.Map<Project>(projectInput);
            projectRepository.CreateProject(projectToCreate);
            projectRepository.Save();

            var projectToReturn = mapper.Map<ProjectDto>(projectToCreate);
            return CreatedAtRoute("GetProject",
                new { projectId = projectToReturn.Id },
                projectToReturn);
        }

        [HttpPut("{projectId}")]
        public ActionResult<ProjectDto> UpdateProject(Guid projectId,
        ProjectForCreationDto projectInput)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            var projectToUpdate = mapper.Map<Project>(projectInput);
            projectRepository.UpdateProject(projectId, projectToUpdate);
            projectRepository.Save();

            var projectToReturn = mapper.Map<ProjectDto>(
                projectRepository.GetProject(projectId));
            return CreatedAtRoute("GetProject",
                new { projectId = projectToReturn.Id },
                projectToReturn);
        }

        [HttpDelete("{projectId}")]
        public ActionResult DeleteProject(Guid projectId)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            if (projectRepository
                .GetProjectIncludedExpertsAndRoles(projectId)
                .ProjectExperts.Count > 0)
            {
                projectRepository.RemoveProjectExperts(projectId);
            }

            projectRepository.DeleteProject(projectId);
            projectRepository.Save();
            return NoContent();
        }
    }
}
