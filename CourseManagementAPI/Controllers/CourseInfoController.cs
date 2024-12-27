using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseInfoController : ControllerBase
    {
        private readonly ICourseInfoService _courseInfoService;

        public CourseInfoController(ICourseInfoService courseInfoService)
        {
            _courseInfoService = courseInfoService;
        }
        [HttpPost]
        [Route("AddCourseInfoAsync")]
        public async Task<IActionResult> Post([FromBody] List<CourseInfoModel> courseInfoModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var cources = await _courseInfoService.AddCourseInfoAsync(courseInfoModel);

                return Ok(cources);

                // return StatusCode(StatusCodes.Status201Created, "course Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

    }
}
