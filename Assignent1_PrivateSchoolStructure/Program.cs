using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignent1_PrivateSchoolStructure
{
    class Program
    {
        static void Main(string[] args)
        {

            CultureInfo myCI = new CultureInfo("el-GR");
            var random = new Random();
            var school = new School();

            Console.WriteLine("===== Welcome to school management portal =====\n");

            Console.WriteLine("Note1: A course assignment has not oral/total mark and cannot be created without passing a valid course.");
            Console.WriteLine("Note2: Each student(personal) assignment inherits from the corresponding course assignment and has oral and total mark.");
            Console.WriteLine("Note3: When a new assigment is added to a course, the system will automatically create personal assigments for all students assigned to that course.");
            Console.WriteLine("Note4: When a new student is added to a course, the system will create his personal assignments based on all assignments the course has.");
            Console.WriteLine("Note5: Assignment title will be automatically set based on the number of assignments a course has. E.g. the title of the first assignment of a course will be set to \"Assignment1\", the title of the second assignment of the same course will be set to \"Assignment2\" etc.\n");

            string mainMenuSelection = String.Empty;
            while (mainMenuSelection.ToLower() != "q")
            {
                Console.WriteLine("Enter the number that corresponds to the desired action or type \"q\" to quit.");
                Console.WriteLine("(1) Course creation menu");
                Console.WriteLine("(2) Student creation menu");
                Console.WriteLine("(3) Trainer creation menu");
                Console.WriteLine("(4) Defining relationships between courses/students/trainers menu");
                Console.WriteLine("(5) Course assignments creation menu");
                Console.WriteLine("(6) Reports menu");
                Console.Write("Select action: ");

                mainMenuSelection = Console.ReadLine();
                Console.WriteLine();

                switch (mainMenuSelection)
                {
                    case ("1"):
                        String subMenu1Selection = String.Empty;
                        while (subMenu1Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Course Creation Menu =====");
                            Console.WriteLine("(1) Create manually a course");
                            Console.WriteLine("(2) Create a number of random courses");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Select action: ");
                            subMenu1Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu1Selection)
                            {
                                case ("1"):
                                    Console.WriteLine("Enter course Title, Stream, Type, Start Date(year,month,day) separated by komma.");
                                    Console.WriteLine("Course End Date will be automatically set based on Type(Full time => 3 months, Part time => 6 months)");
                                    Console.Write("Course info: ");
                                    try
                                    {
                                        school.CreateCourseFromUserInput(Console.ReadLine(), random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("2"):
                                    Console.Write("Enter the number of courses to create (max 200): ");
                                    try
                                    {
                                        int numberOfCoursesToCreate = Int32.Parse(Console.ReadLine());
                                        school.AddRandomCourses(SyntheticData.CourseTitles, numberOfCoursesToCreate, random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("b"):
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("2"):
                        String subMenu2Selection = String.Empty;
                        while (subMenu2Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Student Creation menu =====");
                            Console.WriteLine("(1) Create manually a student");
                            Console.WriteLine("(2) Create a number of random students (max: 200)");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Selection: ");
                            subMenu2Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu2Selection)
                            {
                                case ("1"):
                                    Console.Write("Enter student's First Name, Last Name, Date of Birth(year,month,day) separated by komma.\nStudent info: ");
                                    try
                                    {
                                        school.CreateStudentFromUserInput(Console.ReadLine(), random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("2"):
                                    Console.Write("Enter the number of students to create (max 200): ");
                                    try
                                    {
                                        int numberOfStudentsToCreate = Int32.Parse(Console.ReadLine());
                                        school.AddRandomStudents(SyntheticData.FirstNames, SyntheticData.LastNames, numberOfStudentsToCreate, random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("b"):
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("3"):
                        String subMenu3Selection = String.Empty;
                        while (subMenu3Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Trainer Creation menu =====");
                            Console.WriteLine("(1) Create manually a trainer");
                            Console.WriteLine("(2) Create a number of random trainers (max: 200)");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Selection: ");
                            subMenu3Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu3Selection)
                            {
                                case ("1"):
                                    Console.Write("Enter trainer's First Name, Last Name, Subject\nTrainer info: ");
                                    try
                                    {
                                        school.CreateTrainerFromUserInput(Console.ReadLine(), random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("2"):
                                    Console.Write("Enter the number of trainers to create (max 200): ");
                                    try
                                    {
                                        int numberOfTrainersToCreate = Int32.Parse(Console.ReadLine());
                                        school.AddRandomTrainers(SyntheticData.FirstNames, SyntheticData.LastNames, SyntheticData.TrainerSubjects, numberOfTrainersToCreate, random);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    Console.WriteLine();
                                    break;

                                case ("b"):
                                    Console.WriteLine();
                                    break;
                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("4"):
                        String subMenu4Selection = String.Empty;
                        while (subMenu4Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Defining relationships between courses/students/trainers menu =====");
                            Console.WriteLine("(1) Assign manually a student to a course");
                            Console.WriteLine("(2) Assign random number of students to a course");
                            Console.WriteLine("(3) Assign random number of students to a random course");
                            Console.WriteLine("(4) Assign random number of students to each course.");
                            Console.WriteLine("(5) Assign manually a trainer to a course");
                            Console.WriteLine("(6) Assign random number of trainers to a course");
                            Console.WriteLine("(7) Assign random number of trainers to a random course");
                            Console.WriteLine("(8) Assign random number of trainers to each course");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Select action: ");
                            subMenu4Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu4Selection)
                            {
                                case ("1"):
                                    {
                                        try
                                        {
                                            school.PrintAllStudentsLite();
                                            Console.WriteLine();
                                            Console.Write("Enter student id: ");
                                            var studentId = Int32.Parse(Console.ReadLine());
                                            Console.WriteLine();
                                            school.PrintAllCourses();
                                            Console.WriteLine();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            school.AssignStudentToACourse(studentId, courseId);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("2"):
                                    {
                                        try
                                        {
                                            school.PrintAllCourses();
                                            Console.WriteLine();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            school.AssignRandomNumberOfStudentsToACourse(courseId, random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("3"):
                                    {
                                        try
                                        {
                                            school.AssignRandomNumberOfStudentsToARandomCourse(random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("4"):
                                    {
                                        try
                                        {
                                            school.RandomlyAssignStudentsToAllCourses(random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }


                                case ("5"):
                                    {
                                        try
                                        {
                                            school.PrintAllTrainers();
                                            Console.WriteLine();
                                            Console.Write("Enter trainer id: ");
                                            var trainerId = Int32.Parse(Console.ReadLine());
                                            Console.WriteLine();
                                            school.PrintAllCourses();
                                            Console.WriteLine();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            school.AssignTrainerToCourse(trainerId, courseId);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("6"):
                                    {
                                        try
                                        {
                                            school.PrintAllCourses();
                                            Console.WriteLine();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            school.AssignRandomNumberOfTrainersToACourse(courseId, random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("7"):
                                    {
                                        try
                                        {
                                            school.AssignRandomNumberOfTrainersToARandomCourse(random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("8"):
                                    {
                                        try
                                        {
                                            school.RandomlyAssignTrainersToAllCourses(random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("b"):
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("5"):
                        String subMenu5Selection = String.Empty;
                        while (subMenu5Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Course assignments creation menu =====");
                            Console.WriteLine("(1) Create manually an assignment for a course");
                            Console.WriteLine("(2) Create a number of random assignments for a course");
                            Console.WriteLine("(3) Create random number(max 5) of assignments for all courses");
                            Console.WriteLine("(4) Set total marks for all student assignments of a course to random values");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Select action: ");
                            subMenu5Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu5Selection)
                            {
                                case ("1"):
                                    {
                                        try
                                        {
                                            if (school.Courses.Count != 0)
                                                school.PrintAllCourses();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter assigments's Description, Submission DateAndTime(yyyy,MM,dd hh:mm) separated by komma.");
                                            Console.Write("Assignment info: ");
                                            var assignmentInfo = Console.ReadLine();
                                            school.CreateAssignmentFromUserInput(assignmentInfo, courseId);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("2"):
                                    {
                                        try
                                        {
                                            if (school.Courses.Count != 0)
                                                school.PrintAllCourses();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            Console.Write("Enter number of assignments to create: ");
                                            var numberOfAssignments = Int32.Parse(Console.ReadLine());
                                            school.AddRandomAssignmentsToACourse(courseId, numberOfAssignments, SyntheticData.AssignmentDescriptions, random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("3"):
                                    {
                                        try
                                        {
                                            school.AddRandomNumberOfAssignmetsToAllCourses(5, SyntheticData.AssignmentDescriptions, random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("4"):
                                    {
                                        try
                                        {
                                            if (school.Courses.Count != 0)
                                                school.PrintAllCourses();
                                            Console.Write("Enter course id: ");
                                            var courseId = Int32.Parse(Console.ReadLine());
                                            school.SetRandomMarkToAllStudentsAssignmetsOfACourse(courseId, random);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("b"):
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("6"):
                        String subMenu6Selection = String.Empty;
                        while (subMenu6Selection.ToLower() != "b")
                        {
                            Console.WriteLine("===== Reports menu =====");
                            Console.WriteLine("(1) Print list of all courses");
                            Console.WriteLine("(2) Print list of all students");
                            Console.WriteLine("(3) Print list of all trainers");
                            Console.WriteLine("(4) Print students per course");
                            Console.WriteLine("(5) Print course assignments per course");
                            Console.WriteLine("(6) Print student assignments per course");
                            Console.WriteLine("(7) Print personal assignments per student");
                            Console.WriteLine("(8) Print trainers per course");
                            Console.WriteLine("(9) Print students that belong to more than one courses");
                            Console.WriteLine("(10) Print students that need to submit one or more assignments on a given date");
                            Console.WriteLine("Type 'b' to return to main menu");
                            Console.Write("Select action: ");
                            subMenu6Selection = Console.ReadLine();
                            Console.WriteLine();

                            switch (subMenu6Selection)
                            {
                                case ("1"):
                                    {
                                        try
                                        {
                                            school.PrintAllCourses();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("2"):
                                    {
                                        try
                                        {
                                            school.PrintAllStudents();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }


                                case ("3"):
                                    {
                                        try
                                        {
                                            school.PrintAllTrainers();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("4"):
                                    {
                                        try
                                        {
                                            school.PrintStudentsForAllCourses();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("5"):
                                    {
                                        try
                                        {
                                            school.PrintAssignmentsForAllCourses();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("6"):
                                    {
                                        try
                                        {
                                            school.PrintAllStudentAssignmentsForAllCourses();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("7"):
                                    {
                                        try
                                        {
                                            school.PrintAllAssignmentsPerStudent();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("8"):
                                    {
                                        try
                                        {
                                            school.PrintTrainersForAllCourses();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("9"):
                                    {
                                        try
                                        {
                                            school.PrintStudentsThatBelongToMoreThanOneCourse();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("10"):
                                    {
                                        try
                                        {
                                            Console.Write("Enter date: ");
                                            DateTime date = DateTime.Parse(Console.ReadLine());
                                            school.PrintStudentsThatNeedToSubmitAssigmentsInTheSpecifiedWeek(date, myCI);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.WriteLine();
                                        break;
                                    }

                                case ("b"):
                                    break;

                                default:
                                    Console.WriteLine("Selection is not recognized.");
                                    break;
                            }
                        }
                        break;

                    case ("q"):
                        Console.WriteLine("Goodbye");
                        break;

                    default:
                        Console.WriteLine("Unrecognized selection\n");
                        break;
                }
            }
        }
    }
}
