using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Models.Admin;
using AllocateYourExperts.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocateYourExperts.API.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository authRepository;
        private readonly IMapper mapper;

        public AuthenticationController(IAuthenticationRepository authenticationRepository,
            IMapper mapper)
        {
            authRepository = authenticationRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("api/signup")]
        [AllowAnonymous]
        public ActionResult<AdminDto> SignUp(SignUpDto input)
        {
            if (input == null)
                return BadRequest();

            if (authRepository.AdminAlredyExist(input.Email))
                return BadRequest("There is already a user with the specified email address");

            var adminToCreate = mapper.Map<Admin>(input);
            authRepository.CreateAdmin(adminToCreate, input.Password);
            authRepository.Save();

            var adminToCopy = authRepository.GetAuthAdmin(input.Email, input.Password);
            var adminToReturn = mapper.Map<AdminDto>(adminToCopy);
            adminToReturn.Token = authRepository.GetToken(adminToCopy);           
            return Ok(adminToReturn);
        }

        [HttpPost]
        [Route("api/signin")]
        [AllowAnonymous]
        public ActionResult<AdminDto> SignIn(SignInDto input)
        {
            if (input == null)
                return BadRequest();

            var admin = authRepository.GetAuthAdmin(input.Email, input.Password);
            if(admin == null)
                return BadRequest("Incorrect email or password");

            var adminToReturn = mapper.Map<AdminDto>(admin);
            adminToReturn.Token = authRepository.GetToken(admin);
            return Ok(adminToReturn);

        }
    }
}
