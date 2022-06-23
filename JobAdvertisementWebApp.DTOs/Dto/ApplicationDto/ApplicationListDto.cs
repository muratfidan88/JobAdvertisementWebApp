namespace JobAdvertisementWebApp.DTOs
{
    public class ApplicationListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
    }
}
