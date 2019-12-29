using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.Admin;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocateYourExperts.API.AMProfiles
{
    public class AdminAMProfile : Profile
    {
        public AdminAMProfile()
        {
            CreateMap<Admin, AdminDto>();
            CreateMap<SignUpDto, Admin>();
        }
    }
}
