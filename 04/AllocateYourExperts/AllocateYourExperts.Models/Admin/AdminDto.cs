using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Models.Admin
{
    public class AdminDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string Hash { get; set; }
        public string Token { get; set; }
    }
}
