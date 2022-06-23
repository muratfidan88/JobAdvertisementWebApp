using System;

namespace JobAdvertisementWebApp.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate  { get; set; }
        public Advertisement Advertisement { get; set; }
        public AppUser AppUser { get; set; }
    }
}
