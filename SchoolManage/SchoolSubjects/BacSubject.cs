using System.ComponentModel.DataAnnotations;

namespace SchoolManage.SchoolSubjects
{
    public class BacSubject
    {
        public int Id { get; set; }
        [MaxLength(12)]
        public string Name { get; set; }
    }
}
