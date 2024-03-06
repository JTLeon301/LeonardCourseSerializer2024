using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardCourseSerializer2024
{
    [Serializable] public class Course
    {
        //properties
        public string CourseNumber { get; set; }
        public String CourseTitle { get; set; }
        public string CourseDescription { get; set; }

        //default contructor
        public Course()
        {
            CourseNumber = string.Empty;
            CourseTitle = string.Empty;
            CourseDescription = string.Empty;
        }

        //non-default constructor
        public Course(string courseNumber, string courseTitle, string courseDescription)
        {
            CourseNumber = courseNumber;
            CourseTitle = courseTitle;
            CourseDescription = courseDescription;
        }

        //ToString method
        public override string ToString()
        {
            return $"Number: {CourseNumber}\nName: {CourseTitle}\nDescription: {CourseDescription}";
        }

        //course factory
        public Course CreateCourse(string description)
        {
            string[] parts = description.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            Course result = new Course(parts[1], parts[2], parts[3]);
            return result;
        }
    }
}
