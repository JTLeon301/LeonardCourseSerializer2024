using static System.Console;

/*
 * NAME: Jaiden Leonard
 * CLASS: >Net Programming
 * ASSIGNMENT: Serialization
 * DATE: 3/5/2024
 * 
 * PURPOSE:
 * The purpose of this program is to take in x amount of classes that the user specifies and asks for the number,
 * title, and description. It then takes it and puts them into .txt, .bin, .xml, and .json files to then be read back
 * to them in the console.
 * 
 * STRUGGLES:
 * I have spent the last 3 hours trying to figure out why it will not read from the .txt file but it reads from
 * literally every other file. I watched the recoding of the lecture from last week numerous times when you set the
 * classes needed up and I cannot for the life of me figure out what I've done wrong for it. I went so far as to consult
 * ChatGPT to try and problem solve it because I have no idea and even it couldn't figure out what was wrong. If you are 
 * able to figure it out, you a a wizard, or I'm just really dumb/blind. If you do figure it out though, please let me
 * know.
 * 
 * NOTE:
 * If you notice anything I could improve on or change, feel free to leave a comment on the assignment grading page.
 * All feedback positive or negative is welcomed. Thank you!
*/

namespace LeonardCourseSerializer2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialize variables
            string firstName = string.Empty;
            string directoryPath = string.Empty;
            int numOfCourses = 0;
            List<Course> courses = new List<Course>();

            //print header
            WriteLine("**************************************************************");
            WriteLine("                 Course Management Tool");
            WriteLine("**************************************************************");
            WriteLine();

            //ask user for thier name
            Write("What is your first name? ");
            firstName = ReadLine();
            WriteLine();

            //ask the user how many courses they want to enter
            Write("How many courses will you enter? ");
            numOfCourses = int.Parse(ReadLine());
            WriteLine();

            //for loop to iterate through how many classes they want to add
            for (int i = 1; i<= numOfCourses; i++)
            {
                //ask the user for the course number
                Write("Enter course number: ");
                string courseNumber = ReadLine();

                //ask the user for the course title
                Write("Enter course title: ");
                string courseTitle = ReadLine();

                //ask the user for the course description
                Write("Enter course description: ");
                string courseDescription = ReadLine();

                //create list of courses
                Course newCourse = new Course(courseNumber, courseTitle, courseDescription);
                courses.Add(newCourse);

                //writeline to space the next set of questions
                WriteLine();
            }

            //output to the user the courses they have added
            WriteLine("These are the courses you entered:");
            CourseWriter.WriteCoursesToScreen(courses);
            WriteLine();

            //ask user for the directory they want the files in
            Write("Enter directory to save the courses to: ");
            directoryPath = ReadLine();

            //initialize fileName for each type
            string txtFileName = $"{firstName}.txt";
            string binFileName = $"{firstName}.bin";
            string xmlFileName = $"{firstName}.xml";
            string jsonFileName = $"{firstName}.json";

            //output to user where the courses are being saved to
            WriteLine();
            WriteLine($"I will now save these courses to {txtFileName}, {binFileName}, {xmlFileName}, and {jsonFileName} in directory {directoryPath}");

            //initialize DataSerializer and completeFilePath(s)
            DataSerializer ds = new DataSerializer();
            string completeTxtFilePath = directoryPath + txtFileName;
            string completeBinFilePath = directoryPath + binFileName;
            string completeXmlFilePath = directoryPath + xmlFileName;
            string completeJsonFilePath = directoryPath + jsonFileName;

            //output to user that the program will read it back
            WriteLine();
            WriteLine("I will now read these files back into four seperate lists to prove they were serialized correctly.");
            WriteLine();

            //output the user's courses to the console from their respective file
            //deal with .txt file >:(
            List<Course>? readFromTxt;
            if (CourseWriter.WriteCoursesToFile(courses, completeTxtFilePath))
            {
                WriteLine("From the text file:");
                readFromTxt = CourseReader.ReadCoursesFromFile(completeTxtFilePath);
                if (readFromTxt != null)
                {
                    CourseWriter.WriteCoursesToScreen(readFromTxt);
                } else
                {
                    WriteLine("\nCould not read the file.\n");
                }
            } else
            {
                WriteLine("\nCould not write to file.\n");
            }
            //bin
            WriteLine("From the binary file:");
            ds.BinarySerialize(courses, completeBinFilePath);
            List<Course> readFromBinary;
            readFromBinary = ds.BinaryDeserialize(completeBinFilePath) as List<Course>;
            CourseWriter.WriteCoursesToScreen(readFromBinary);
            WriteLine();
            //xml
            WriteLine("From the xml file:");
            ds.XmlSerialize(typeof(List<Course>), courses, completeXmlFilePath);
            List<Course> readFromXml;
            readFromXml = ds.XmlDeserialize(typeof(List<Course>), completeXmlFilePath) as List<Course>;
            CourseWriter.WriteCoursesToScreen(readFromXml);
            WriteLine();
            //json
            WriteLine("From the json file");
            ds.JsonSerialize(courses, completeJsonFilePath);
            List<Course> readFromJson;
            readFromJson = ds.JsonDeserialize<List<Course>>(completeJsonFilePath);
            CourseWriter.WriteCoursesToScreen(readFromJson);

            //program termination message
            WriteLine();
            WriteLine("**************************************************************");
            WriteLine("             Thank you for using this program");
            WriteLine("**************************************************************");
        }
    }
}
