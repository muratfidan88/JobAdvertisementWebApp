using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public AppRole AppRole { get; set; }
        public MemberCv MemberCv { get; set; }
        public List<Company> Companies { get; set; }
        public List<Application> Applications { get; set; }
    }
}
