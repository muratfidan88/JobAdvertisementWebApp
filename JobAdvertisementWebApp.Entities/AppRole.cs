using System.Collections.Generic;

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
