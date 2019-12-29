using AllocateYourExperts.DataAccess;
using AllocateYourExperts.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AllocateYourExperts.Services
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppSettings appSettings;
        private readonly AYEDbContext context;

        public AuthenticationRepository(IOptions<AppSettings> appSettings,
            AYEDbContext context)
        {
            this.appSettings = appSettings.Value;
            this.context = context;
        }

        private byte[] GetSalt()
        {
            var salt = appSettings.Salt;
            return Encoding.ASCII.GetBytes(salt);
        }

        private string GetHashString(string password)
        {
            var hashString = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                  password: password,
                  salt: this.GetSalt(),
                  prf: KeyDerivationPrf.HMACSHA1,
                  iterationCount: appSettings.Iteration,
                  numBytesRequested: 256 / 8
                    ));

            if (hashString == null)
                return null;

            return hashString;
        }

        public void CreateAdmin(Admin admin,
            string password)
        {
            var adminToCreate = admin;
            adminToCreate.Id = Guid.NewGuid();
            adminToCreate.Hash = this.GetHashString(password);
            context.Admins.Add(adminToCreate);
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return context.Admins;
        }

        public bool AdminAlredyExist(string email)
        {
            return this.GetAdmins().Any(a => a.Email == email);
        }

        void IAuthenticationRepository.Save()
        {
            context.SaveChanges();
        }

        public string GetToken(Admin admin)
        {           
            var tokenHandler = new JwtSecurityTokenHandler();
            var authKey = Encoding.ASCII.GetBytes(appSettings.AuthKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(authKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Admin GetAuthAdmin(string email, string password)
        {
            var hashString = this.GetHashString(password);
            var admin = this.GetAdmins()
                .FirstOrDefault(a => a.Email == email && a.Hash == hashString);
            if (admin == null)
                return null;
            else return admin;
        }

        //public Admin GetAdmin(Guid id)
        //{
        //    if (this.GetAdmins().Count() == 1)
        //    {
        //        return this.GetAdmins().First();
        //    }
        //}
    }
}
