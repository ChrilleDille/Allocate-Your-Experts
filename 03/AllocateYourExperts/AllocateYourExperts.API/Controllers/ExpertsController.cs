using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ExpertDtos;
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
    [Route("api/experts")]
    public class ExpertsController : ControllerBase
    {
        private readonly IExpertRepository expertRepository;
        private readonly IMapper mapper;

        public ExpertsController(IExpertRepository expertRepository,
            IMapper mapper)
        {
            this.expertRepository = expertRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExpertDto>> GetExperts()
        {
            var experts = expertRepository.GetExperts();
            if (!experts.Any())
            {
                return NotFound("There are currently no experts, please add");
            }

            var expertsToReturn = mapper.Map<IEnumerable<ExpertDto>>(experts);
            return Ok(expertsToReturn);
        }

        [HttpGet("{expertId}", Name = "GetExpert")]
        public ActionResult<ExpertDto> GetExpert(Guid expertId)
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            var expertToReturn = mapper.Map<ExpertDto>(expertRepository.GetExpert(expertId));
            return Ok(expertToReturn);
        }

        [HttpPost]
        public ActionResult<ExpertDto> CreateExpert(ExpertForCreationDto expertInput)
        {
            var expertToCreate = mapper.Map<Expert>(expertInput);
            expertRepository.CreateExpert(expertToCreate);
            expertRepository.Save();

            var expertToReturn = mapper.Map<ExpertDto>(expertToCreate);
            return CreatedAtRoute("GetExpert", new { expertId = expertToReturn.Id },
                expertToReturn);
        }

        [HttpPut("{expertId}")]
        public ActionResult<ExpertDto> UpdateExpert(Guid expertId, 
            ExpertForCreationDto expertInput) 
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            var expertToUpdate = mapper.Map<Expert>(expertInput);
            expertRepository.UpdateExpert(expertId, expertToUpdate);
            expertRepository.Save();

            var expertToReturn = mapper.Map<ExpertDto>(expertRepository.GetExpert(expertId));
            return CreatedAtRoute("GetExpert", new {expertId = expertToReturn.Id},
                expertToReturn);
        }

        [HttpDelete("{expertId}")]
        public ActionResult DeleteExpert(Guid expertId) 
        {
            if (!expertRepository.ExpertExist(expertId))
            {
                return NotFound();
            }

            if (expertRepository
                .GetExpertIncludedProjectsAndRoles(expertId)
                .ExpertProjects.Count > 0)
            {
                expertRepository.RemoveProjectsFromExpert(expertId);
            }

            expertRepository.DeleteExpert(expertId);
            expertRepository.Save();
            return NoContent();
        }
    }
}
