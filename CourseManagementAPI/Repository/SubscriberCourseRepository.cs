using CourseManagementAPI.DBContext;
using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementAPI.Repository
{
    public class SubscriberCourseRepository : ISubscriberCourseRepository
    {
        private readonly AppDbContext _context;

        public SubscriberCourseRepository(AppDbContext context)
        {
            _context = context;
        }

    

        public bool AddCourseDetails(SubscriberCourse subscriberCourse)
        {
            _context.SubscriberCourses.Add(subscriberCourse);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCourseDetails(int id)
        {
            SubscriberCourse subscriberCourse = _context.SubscriberCourses.SingleOrDefault();
            if (subscriberCourse != null)
            {
                _context.SubscriberCourses.Remove(subscriberCourse);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool UpdateCourseDetails(SubscriberCourse subscriberCourse)
        {
            _context.SubscriberCourses.Update(subscriberCourse);
            _context.SaveChanges();
            return true;
        }
    }
}
