using System.Collections.Generic;

namespace JobAdvertisementWebApp.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Defination { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Advertisement> Advertisements { get; set; }

    }
}
