using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ExpertDtos;
using AllocateYourExperts.Models.ProjectTeamDtos;
using AutoMapper;

namespace AllocateYourExperts.API.AMProfiles
{
    public class ExpertAMProfile : Profile
    {
        public ExpertAMProfile()
        {
            CreateMap<Expert, ExpertDto>();
            CreateMap<ExpertForCreationDto, Expert>();
        }
    }
}