using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardCourseSerializer2024
{
    internal class CourseReader
    {
        //read courses from txt file
        public static List<Course>? ReadCoursesFromFile(string filePath)
        {
            try
            {
                List <Course> result = new List<Course>();
                CourseFactory factory = new CourseFactory(new Course());
                string line;
                Course c;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Trim();
                        c = factory.CreateCourse(line);
                        result.Add(c);
                    }
                }
                return result;
            } catch (Exception ex)
            {
                return null;
            }
        }
    }
}
