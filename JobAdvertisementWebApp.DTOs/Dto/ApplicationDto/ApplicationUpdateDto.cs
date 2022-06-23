namespace JobAdvertisementWebApp.DTOs
{
    public class ApplicationUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
    }
}
