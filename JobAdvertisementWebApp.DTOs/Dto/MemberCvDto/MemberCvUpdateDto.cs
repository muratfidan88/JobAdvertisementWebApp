using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DTOs
{
    public class MemberCvUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string SchoolName { get; set; }
        public string RecentWorkName { get; set; }
        public int WorkExperience { get; set; }
        public int UserId { get; set; }
    }
}
