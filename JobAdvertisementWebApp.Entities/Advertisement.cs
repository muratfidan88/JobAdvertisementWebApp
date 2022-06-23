using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Application> Applications { get; set; }
    }
}
