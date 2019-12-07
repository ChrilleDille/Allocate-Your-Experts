using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ExpertProjectsDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocateYourExperts.API.AMProfiles
{
    public class ExpertProjectsDtoAMProfile : Profile
    {
        public ExpertProjectsDtoAMProfile()
        {
            CreateMap<ProjectExpertRole, ExpertProjectsDto>()
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ProjectId)
                )
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Project.Name)
                )
                .ForMember(
                dest => dest.StartDate,
                opt => opt.MapFrom(src => src.Project.StartDate)
                )
                .ForMember(
                dest => dest.EndDate,
                opt => opt.MapFrom(src => src.Project.EndDate)
                )
                .ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => src.Project.IsActive)
                )
                .ForMember(
                dest => dest.ExpertName,
                opt => opt.MapFrom(src => src.Expert.Name)
                )
                .ForMember(
                dest => dest.ExpertRole,
                opt => opt.MapFrom(src => src.Role.Name)
                );

            CreateMap<ExpertProjectsForCreationDto, ProjectExpertRole>();
        }
                       
    }
}
