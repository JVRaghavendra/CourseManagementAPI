﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagementAPI.Entity
{
    [Table("CourseInfoSubscriber")]
    public class CourseInfo
    {
        [Key]
        public long SubscriberID { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public decimal CourseHours { get; set; }
        public string ContentLevel { get; set; }
        public string SessionID { get; set; }
        public string CurriculumDispCat { get; set; }
        public DateTimeOffset SubscribedDateTime { get; set; }
        public string Payload { get; set; }
    }
}
