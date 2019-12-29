using AllocateYourExperts.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Services
{
    public interface IAuthenticationRepository
    {
        void CreateAdmin(Admin admin, string password);
        IEnumerable<Admin> GetAdmins();
        bool AdminAlredyExist(string email);
        //Admin GetAdmin(Guid id);
        Admin GetAuthAdmin(string email, string password);
        string GetToken(Admin admin);
        void Save();
    }
}
