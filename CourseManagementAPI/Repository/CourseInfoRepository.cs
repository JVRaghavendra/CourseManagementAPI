using CourseManagementAPI.DBContext;
using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;

namespace CourseManagementAPI.Repository
{
    public class CourseInfoRepository : ICourseInfoRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseInfoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddCourseInfoAsync(List<CourseInfo> courses)
        {
            try
            {
                _appDbContext.CourseInfoSubscriber.AddRangeAsync(courses);
                _appDbContext.SaveChanges();
                return true;


            }

            catch (Exception ex)
            {

                return false;

            }
               

            

        }

       
    }
}
