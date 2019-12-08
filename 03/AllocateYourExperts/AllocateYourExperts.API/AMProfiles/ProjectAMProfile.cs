using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ProjectDtos;
using AutoMapper;

namespace AllocateYourExperts.API.AMProfiles
{
    public class ProjectAMProfile : Profile
    {
        public ProjectAMProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectForCreationDto, Project>();
        }
    }
}
