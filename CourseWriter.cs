using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LeonardCourseSerializer2024
{
    internal class CourseWriter
    {
        //write courses to screen
        public static void WriteCoursesToScreen(List<Course> courseList)
        {
            foreach (Course c in courseList)
            {
                WriteLine(c);
            }
        }

        //write courses to file
        public static bool WriteCoursesToFile(List<Course> courseList, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (Course c in courseList)
                    {
                        sw.WriteLine(c);
                    }
                }
                return true;
            } catch (Exception e)
            {
                return false;
            }
        }
    }
}
