using CourseManagementAPI.Entity;
using CourseManagementAPI.Model;

namespace CourseManagementAPI.Interfaces
{
    public interface ISubscriberCourseRepository
    {

        bool AddCourseDetails(SubscriberCourse subscriberCourse);

        bool UpdateCourseDetails(SubscriberCourse subscriberCourse);
        bool DeleteCourseDetails(int id);
    }
}
