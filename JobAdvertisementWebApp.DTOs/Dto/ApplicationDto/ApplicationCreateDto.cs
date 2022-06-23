namespace JobAdvertisementWebApp.DTOs
{
    public class ApplicationCreateDto : IDto
    {
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
    }
}
