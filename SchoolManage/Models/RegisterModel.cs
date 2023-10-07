using System.ComponentModel.DataAnnotations;

namespace SchoolManage.Models
{
    public class RegisterModel
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(75)]
        public string Password { get; set; }

    }
}
