namespace JobAdvertisementWebApp.DTOs
{
    public class CompanyUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Defination { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
