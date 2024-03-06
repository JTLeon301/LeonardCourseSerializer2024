using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardCourseSerializer2024
{
    internal class CourseFactory
    {
        private Course builder;

        //initialize builder
        public CourseFactory(Course course)
        {
            builder = course;
        }

        //create a course
        public Course CreateCourse(string description)
        {
            return builder.CreateCourse(description);
        }
    }
}
