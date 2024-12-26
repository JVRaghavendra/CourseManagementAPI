using CourseManagementAPI.DBContext;
using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public ISubscriberCourseService _courseService;

        public CoursesController(ISubscriberCourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Route("AddCourseDetails")]
        public IActionResult Post([FromBody] Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var cources = _courseService.AddCourseDetails(course);
                return StatusCode(StatusCodes.Status201Created, "course Details Added Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateCourseDetails")]
        public IActionResult PUT([FromBody] Course course)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var courses = _courseService.UpdateCourseDetails(course);
                return StatusCode(StatusCodes.Status201Created, "course Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteCourseDetailsById/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var course = _courseService.DeleteCourseDetails(id);
                return StatusCode(StatusCodes.Status204NoContent, "course details deleted successfully");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
