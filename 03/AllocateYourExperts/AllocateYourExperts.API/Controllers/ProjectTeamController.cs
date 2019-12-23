using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models;
using AllocateYourExperts.Models.ProjectTeamDtos;
using AllocateYourExperts.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllocateYourExperts.API.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/projectteam")]
    public class ProjectTeamController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;
        private readonly IMapper mapper;

        public ProjectTeamController(IProjectRepository projectRepository,
            IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetProjectTeam")]
        public ActionResult<ProjectTeam> GetProjectTeam(Guid projectId)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound("The project you are trying to reach does not exist");
            }

            var projectTeam = projectRepository.GetProjecTeamMap(projectId);
            return Ok(projectTeam);
        }


        [HttpGet("{expertId}", Name = "GetProjectTeamMember")]
        public ActionResult<TeamMember> GetProjectTeamMember(
             Guid projectId, Guid expertId)
        {

            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            if (!projectRepository.ExpertBelongsToProject(projectId, expertId))
            {
                return NotFound();
            }

            var teamMember = projectRepository.GetProjecTeamMap(projectId)
                .Members.FirstOrDefault(tm => tm.Expert.Id == expertId);
            return Ok(teamMember);

        }

        [HttpPost]
        public ActionResult<TeamMember> AddExistingExpertToProjectTeam(Guid projectId,
            TeamMember member)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            var project = projectRepository.GetProjectIncludedExpertsAndRoles(projectId);

            if (projectRepository.ExpertBelongsToProject(project.Id,
             member.Expert.Id))
            {
                var projectExpert = project.ProjectExperts
                    .FirstOrDefault(pe => pe.ExpertId
                    == member.Expert.Id);

                return Conflict($"{projectExpert.Expert.FirstName} " +
                    $"{projectExpert.Expert.LastName} is already a member of {projectExpert.Project.Name}");
            }

            if (projectRepository
                .GetRoleAsLeader().Id == member.Role.Id)
            {
                if (projectRepository.ProjectAlreadyHaveOneLeader(project.Id))
                {
                    var currentProjectLeader = project.ProjectExperts.
                      FirstOrDefault(pe => pe.Role.Id == member.Role.Id)
                      .Expert;
                    // In EF Core there is no easy way to just update-
                    // a many-to-many object.
                    // You need to remove and add. 
                    projectRepository.RemoveExpertFromProject(project.Id,
                        currentProjectLeader.Id);
                    projectRepository.AddProjectExpert(project.Id, currentProjectLeader.Id,
                        projectRepository.GetRoleAsMember().Id);
                }
            }

            projectRepository.AddProjectExpert(project.Id, member.Expert.Id,
                        member.Role.Id);
            projectRepository.Save();

            var teamMemberToReturn = projectRepository.GetProjecTeamMap(project.Id)
                .Members.FirstOrDefault(tm => tm.Expert.Id == member.Expert.Id);
            return CreatedAtRoute("GetProjectTeamMember", new { projectId = project.Id, 
                expertId = teamMemberToReturn.Expert.Id},
            teamMemberToReturn);          
        }

        [HttpPut("{expertId}")]
        public ActionResult<TeamMember> UpdateProjectTeamExpert(Guid projectId,
            Guid expertId, TeamMember member)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            var project = projectRepository.GetProjectIncludedExpertsAndRoles(projectId);

            if (!projectRepository.ExpertBelongsToProject(projectId, expertId))
            {
                return NotFound();
            }

            if (projectRepository.GetRoleAsLeader().Id
              == member.Role.Id)
            {
                if (projectRepository.ProjectAlreadyHaveOneLeader(project.Id))
                {
                    var currentProjectLeader = project.ProjectExperts.
                      FirstOrDefault(pe => pe.Role.Id 
                      == member.Role.Id)
                      .Expert;

                    projectRepository.RemoveExpertFromProject(project.Id,
                     currentProjectLeader.Id);
                    projectRepository.AddProjectExpert(project.Id, currentProjectLeader.Id,
                        projectRepository.GetRoleAsMember().Id);
                }
            }

            projectRepository.RemoveExpertFromProject(project.Id,
                     expertId);
            projectRepository.AddProjectExpert(project.Id, expertId,
                       member.Role.Id);

            projectRepository.Save();

            var teamMemberToReturn = projectRepository.GetProjecTeamMap(project.Id)
                .Members.FirstOrDefault(tm => tm.Expert.Id == expertId);
            return CreatedAtRoute("GetProjectTeamMember", new { projectId = project.Id, expertId = expertId },
            teamMemberToReturn);

        }

        [HttpDelete("{expertId}")]
        public ActionResult RemoveExpertFromProjectTeam(Guid projectId, Guid expertId)
        {
            if (!projectRepository.ProjectExist(projectId))
            {
                return NotFound();
            }

            if (!projectRepository.ExpertBelongsToProject(projectId, expertId))
            {
                return NotFound();
            }

            projectRepository.RemoveExpertFromProject(projectId, expertId);
            projectRepository.Save();
            return NoContent();
        }

    }
}
