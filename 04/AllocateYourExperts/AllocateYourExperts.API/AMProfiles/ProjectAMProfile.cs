using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.ProjectDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocateYourExperts.API.AMProfiles
{
    public class ProjectAMProfile : Profile
    {
        public ProjectAMProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}
