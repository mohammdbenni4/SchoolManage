using System.ComponentModel.DataAnnotations;

namespace SchoolManage.Models
{
    public class AddNewRole
    {
        [MaxLength(60)]
        public string RoleName { get; set; }
    }
}
