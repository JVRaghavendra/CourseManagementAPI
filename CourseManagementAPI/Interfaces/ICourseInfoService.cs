using CourseManagementAPI.Model;

namespace CourseManagementAPI.Interfaces
{
    public interface ICourseInfoService
    {
        Task<bool> AddCourseInfoAsync(List<CourseInfoModel> courseInfoModels);
    }
}
