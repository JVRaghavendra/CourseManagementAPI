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
               await _appDbContext.CourseInfoSubscriber.AddRangeAsync(courses);

                var result = await _appDbContext.SaveChangesAsync();
                // return result;

                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }

            catch (Exception ex)
            {

                return false;

            }
               

            

        }

       
    }
}
