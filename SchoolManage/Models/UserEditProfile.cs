namespace SchoolManage.Models
{
    public class UserEditProfile
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? NewFirstName { get; set; }
        public string? NewLastName { get; set; }
        public string? NewEmail { get; set; }
        public string? Massage { get; set; }
        public IFormFile? NewProfilePicFile { get; set; }
    }
}
