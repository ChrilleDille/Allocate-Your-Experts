using System;
using System.Collections.Generic;
using System.Text;

namespace AllocateYourExperts.Helpers
{
   public class AppSettings
    {
        public string AuthKey { get; set; }
        public string Salt { get; set; }
        public int Iteration { get; set; }
    }
}
