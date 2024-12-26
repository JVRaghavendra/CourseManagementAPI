using CourseManagementAPI.DBContext;
using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Service
{
    public class SubscriberCourseService : ISubscriberCourseService
    {
        public ISubscriberCourseRepository _repository;

        public SubscriberCourseService(ISubscriberCourseRepository repository)
        {
            _repository = repository;
        }

        public bool AddCourseDetails(Course course)
        {
            SubscriberCourse obj = new SubscriberCourse();
            obj.CourseID = course.CourseID;
            obj.CourseName = course.CourseName;
            obj.CourseType = course.CourseType;
            obj.CourseHours = course.CourseHours;
            obj.SessionID = course.SessionID;
            obj.ContentLevel = course.ContentLevel;
            obj.SessionStartDate = course.SubscribedDateTime?.ToUniversalTime().Ticks;
            obj.SessionEndDate = course.SubscribedDateTime?.ToUniversalTime().Ticks;
            obj.SourceName = course.CourseName;
            obj.SourceID = course.SessionID;


            _repository.AddCourseDetails(obj);
            return true;
        }

        public bool DeleteCourseDetails(int id)
        {
            _repository.DeleteCourseDetails(id);
            return true;
        }

        public bool UpdateCourseDetails(Course course)
        {
            SubscriberCourse obj = new SubscriberCourse();
            obj.CourseID = course.CourseID;
            obj.CourseName = course.CourseName;
            obj.CourseType = course.CourseType;
            obj.ContentLevel = course.ContentLevel;
            obj.SessionID = course.SessionID;
            obj.CurriculumDispCat = course.CurriculumDispCat;
            obj.CourseHours = course.CourseHours;

            _repository.UpdateCourseDetails(obj);
            return true;
        }
    }
}
