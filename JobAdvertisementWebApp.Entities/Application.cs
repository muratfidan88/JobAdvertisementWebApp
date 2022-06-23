using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
