using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.Entities
{
    public class AppRole
    {
        public int Id { get; set; }
        public Roles Role { get; set; }
        public List<AppUser> AppUsers { get; set; }

    }

    public enum Roles
    {
        Employer=1,
        Member=2
    }
}
