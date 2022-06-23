using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DTOs
{
    public class AppUserListDto : IDto
    {
        public int Id { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
}
