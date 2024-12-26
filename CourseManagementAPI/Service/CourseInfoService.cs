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
            //// Check if the input list is empty or null
            //if (courseInfoModels == null || courseInfoModels.Count == 0)
            //{
            //    return false;  // Return false if no models to add
            //}
            var models = new List<CourseInfo>();

            var result = false;

            foreach (var model in courseInfoModels)
            {
                var entity = new CourseInfo();

                {
                    entity.SubscriberID = Convert.ToInt64(model.SourceID);
                    entity.CourseID = model.CourseID;
                    entity.CourseName = model.CourseName;
                    entity.CourseType = model.CourseType;
                    entity.CourseHours = model.CourseHours ?? 0; // Default to 0 if null
                    entity.ContentLevel = model.ContentLevel;
                    entity.SessionID = model.SessionID;
                    entity.CurriculumDispCat = model.CurriculumDispCat;
                    entity.SubscribedDateTime = DateTimeOffset.UtcNow;
                    entity.Payload = JsonSerializer.Serialize(model);

                    models.Add(entity);

                }

                // After the loop, call AddCourseInfo once

                result = await _courseInfoRepository.AddCourseInfoAsync(models);


            }

            return result; // Return the result after adding all models

        }
    }
}

//var entities = new List<Learner>();

//foreach (var model in learnerModel)
//{

//    var entity = new Learner();

//    entity.SubscriberID = Convert.ToInt64(model.SourceID);
//    entity.TranscriptID = model.TranscriptID;
//    entity.LearnerID = model.Employee_ID;
//    entity.PeopleKey = model.People_Key;
//    entity.CourseID = model.CourseID;
//    entity.SessionID = model.SessionID;
//    entity.Status = int.Parse(model.Status);
//    entity.CompletionDate = model.CompletionDate;
//    entity.SourceID = model.SourceID;
//    entity.SourceName = model.SourceName;
//    entity.SubscribedDateTime = DateTimeOffset.UtcNow;
//    entity.Payload = JsonSerializer.Serialize(model);
//    entity.IsProcessed = false;


//    entities.Add(entity);
//}

//var result = await _learnerRepository.AddLearnerAsync(entities);
//return result;
//}




//public List<EmployeeDTO> GetAllEmployeeDetails()
//{
//    List<EmployeeDTO> employeeDTOobj = new List<EmployeeDTO>();

//    List<Employee> employees = _employeeRepository.GetAllEmployeeDetails();
//    foreach (Employee employee in employees)
//    {
//        EmployeeDTO obj = new EmployeeDTO();
//        obj.ID = employee.ID;
//        obj.FirstName = employee.FirstName;
//        obj.LastName = employee.LastName;
//        obj.Email = employee.Email;
//        obj.Phone = employee.Phone;
//        obj.Address = employee.Address;
//        obj.Gender = employee.Gender;
//        employeeDTOobj.Add(obj);
//    }
//    return employeeDTOobj;
//}