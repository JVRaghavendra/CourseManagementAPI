using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.Entity
{
    public class SubscriberCourse
    {
        [Key]
        public string? CourseID { get; set; }
        public string? CourseName { get; set; }
        public string? CourseType { get; set; }
        public decimal? CourseHours { get; set; }
        public string? SessionID { get; set; }
        public string? ContentLevel { get; set; }
        public long? SessionStartDate { get; set; }
        public long? SessionEndDate { get; set; }
        public string? CurriculumDispCat { get; set; }
        public string? SourceName { get; set; }
        public string? SourceID { get; set; }
    }
}


//public int SubscriberID { get; set; }
//public int TranscriptID { get; set; }
//public int LearnerID { get; set; }
//public string PeopleKey { get; set; }
//public string CourseID { get; set; }
//public string SessionID { get; set; }
//public string Status { get; set; }
//public DateTime CompletionDate { get; set; }
//public string SourceID { get; set; }
//public string SourceName { get; set; }
//public DateTime SubscribedDateTime { get; set; }
//public string Payload { get; set; }
//public bool IsProcessed { get; set; }

