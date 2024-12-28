using CourseManagementAPI.DBContext;
using CourseManagementAPI.Entity;
using CourseManagementAPI.Interfaces;
using CourseManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.Intrinsics.X86;
using System.Linq.Expressions;

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

            //try
            //{
            //   await _appDbContext.CourseInfoSubscriber.AddRangeAsync(courses);

            //    var result = await _appDbContext.SaveChangesAsync();

            //    // return result;

            //    if(result > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }


            //}

            //catch (Exception ex)
            //{

            //    return false;

            //}

            try
            {
                foreach (var course in courses)
                {
                    // Check if the record already exists based on a unique identifier (e.g., CourseID)

                    var existingRecord = await _appDbContext.CourseInfoSubscriber
                        .FirstOrDefaultAsync(x => x.CourseID == course.CourseID && x.SessionID == course.SessionID);

                    if (existingRecord != null)
                    {
                        // Update the existing record
                        // existingRecord.SubscriberID = Convert.ToInt64(course.SubscriberID);
                      //  existingRecord.CourseID = course.CourseID;
                       // existingRecord.SessionID = course.SessionID;
                        existingRecord.CourseName = course.CourseName;
                        existingRecord.CourseType = course.CourseType;
                        existingRecord.CourseHours = course.CourseHours;
                        existingRecord.ContentLevel = course.ContentLevel;
                        existingRecord.CurriculumDispCat = course.CurriculumDispCat;
                        existingRecord.SubscribedDateTime = course.SubscribedDateTime;
                        existingRecord.Payload = course.Payload;

                        _appDbContext.CourseInfoSubscriber.Update(existingRecord);
                    }
                    else
                    {
                        // Insert new record
                        await _appDbContext.CourseInfoSubscriber.AddRangeAsync(course);
                    }
                }

                // Save all changes
                var result = await _appDbContext.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                // Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }


    }
}


//Key Points of the Solution
//Check for Existing Record:
//Use FirstOrDefaultAsync with a unique combination of fields like CourseID and SessionID to identify existing records.

//Update Existing Record:
//Update fields of the existing record with new values from the course object.

//Insert New Record:
//If no matching record is found, add the new course object to the database.

//Save Changes Once:
//Call SaveChangesAsync after processing all the records to save changes in a single transaction, which improves performance.

//Explanation
//_appDbContext.CourseInfoSubscriber:

//This refers to the CourseInfoSubscriber table in the database, represented as a DbSet in Entity Framework Core.
//_appDbContext is your database context class, typically derived from DbContext, which allows interaction with the database.
//FirstOrDefaultAsync:

//This is an asynchronous LINQ method provided by EF Core.
//It retrieves the first record from the database that matches the given condition.
//If no record matches the condition, it returns null.
//x => x.CourseID == course.CourseID && x.SessionID == course.SessionID:

//This is a lambda expression defining the condition used to search for a record in the database.
//It checks for a record where:
//CourseID in the database (x.CourseID) matches the CourseID in the provided course object.
//SessionID in the database (x.SessionID) matches the SessionID in the provided course object.
//await:

//The method is awaited, meaning it will pause execution until the database query completes, making the method asynchronous and non-blocking.
//Meaning in Context
//The code attempts to find an existing record in the CourseInfoSubscriber table where:

//The CourseID matches the value in the course object.
//The SessionID matches the value in the course object.
//If such a record is found:

//existingRecord will hold the record.
//If no matching record is found:

//existingRecord will be null.
//Common Usage
//This is typically used to:

//Check for Duplicates:

//Ensure the same CourseID and SessionID combination does not already exist.
//Update Existing Records:

//If existingRecord is not null, update the record.
//Insert a New Record:

//If existingRecord is null, insert a new record.