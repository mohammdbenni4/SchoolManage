using System.ComponentModel.DataAnnotations;

namespace SchoolManage.Helpers
{
    public class SearchSubjectByName
    {
        [MaxLength(12)]
        public string Name { get; set; }
    }
}
