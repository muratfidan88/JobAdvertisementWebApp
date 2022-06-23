using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DTOs
{
    public class AppUserSignInDto
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
