using CourseManagementAPI.Entity;
using CourseManagementAPI.Model;

namespace CourseManagementAPI.Interfaces
{
    public interface ISubscriberCourseService
    {
        
        bool AddCourseDetails(Course course);
        bool UpdateCourseDetails(Course course);
        bool DeleteCourseDetails(int id);
    }
}
