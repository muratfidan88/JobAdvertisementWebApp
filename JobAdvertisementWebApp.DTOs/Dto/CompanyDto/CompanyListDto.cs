namespace JobAdvertisementWebApp.DTOs
{
    public class CompanyListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Defination { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
