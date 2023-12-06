namespace PoliSchool.Web.Models
{
    public class CourseListModel
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }

        public int DepartmentId { get; set; }
        public string? Department { get; set; }
        public string? CreationDateDisplay { get; set; }
        public string? EnrollmentDateDisplay { get; set; }
    }
}
