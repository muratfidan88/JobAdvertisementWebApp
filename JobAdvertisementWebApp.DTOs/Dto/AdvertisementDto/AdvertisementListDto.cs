using System;

namespace JobAdvertisementWebApp.DTOs
{
    public class AdvertisementListDto : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Defination { get; set; }
        public DateTime CreaatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int CompanyId { get; set; }
    }
}
