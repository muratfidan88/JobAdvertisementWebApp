namespace JobAdvertisementWebApp.DTOs
{
    public class CompanyCreateDto : IDto
    {
        public string Name { get; set; }
        public string Defination { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
