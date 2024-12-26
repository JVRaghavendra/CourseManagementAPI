using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.Model
{
    public class CourseInfoModel
    {
       
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public decimal? CourseHours { get; set; }
        public string SessionID { get; set; }
        public string ContentLevel { get; set; }
        public string SessionStartDate { get; set; }
        public long? SessionEndDate { get; set; }
        public string CurriculumDispCat { get; set; }
        public string SourceName { get; set; }
        public int? SourceID { get; set; }
    }
}
