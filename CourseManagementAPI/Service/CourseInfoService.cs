using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using System.Text.Json;

namespace CourseManagementAPI.Service
{
    public class CourseInfoService : ICourseInfoService
    {
        private readonly ICourseInfoRepository _courseInfoRepository;

        public CourseInfoService(ICourseInfoRepository courseInfoRepository)
        {
            _courseInfoRepository = courseInfoRepository;
        }
      
        public async Task<bool> AddCourseInfoAsync(List<CourseInfoModel> courseInfoModels)
        {
            
            try
            {
                var models = new List<CourseInfo>();

                foreach (var model in courseInfoModels)
                {


                    var entity = new CourseInfo();

                    {
                        entity.SubscriberID = Convert.ToInt64(model.SourceID);
                        entity.CourseID = model.CourseID;
                        entity.CourseName = model.CourseName;
                        entity.CourseType = model.CourseType;
                        entity.CourseHours = model.CourseHours ?? 0; // Default to 0 if null
                        //entity.CourseHours = model.CourseHours.HasValue ? Convert.ToDecimal(model.CourseHours.Value) : 0m;

                        entity.ContentLevel = model.ContentLevel;
                        entity.SessionID = model.SessionID;
                        entity.CurriculumDispCat = model.CurriculumDispCat;
                        entity.SubscribedDateTime = DateTimeOffset.UtcNow;
                        entity.Payload = JsonSerializer.Serialize(model);

                        models.Add(entity);

                    }
                }

                var result = await _courseInfoRepository.AddCourseInfoAsync(models);

                return result; // Return the result after adding all models

            }

            catch (Exception ex)
            {
                throw;
            }            
            

        }
    }
}






