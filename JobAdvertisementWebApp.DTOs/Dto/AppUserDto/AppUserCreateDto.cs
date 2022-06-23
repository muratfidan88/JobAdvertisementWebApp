namespace JobAdvertisementWebApp.DTOs
{
    public class AppUserCreateDto : IDto
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    }
}
