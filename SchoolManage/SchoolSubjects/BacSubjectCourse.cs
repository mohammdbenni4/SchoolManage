namespace SchoolManage.SchoolSubjects
{
    public class BacSubjectCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BacSubjectId { get; set; }
        public BacSubject BacSubject { get; set; }
    }
}
