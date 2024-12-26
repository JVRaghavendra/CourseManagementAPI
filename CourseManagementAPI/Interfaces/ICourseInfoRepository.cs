using CourseManagementAPI.Entity;

namespace CourseManagementAPI.Interfaces
{
    public interface ICourseInfoRepository
    {
        Task<bool> AddCourseInfoAsync(List<CourseInfo> courses);
    }
}
