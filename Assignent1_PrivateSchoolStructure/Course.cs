using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public StreamType Stream { get; set; }
        public CourseType Type { get; set; }
        public List<Student> Students { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Trainer> Trainers { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get
            {
                if (Type == CourseType.FullTime)
                    return StartDate.AddMonths(3);
                return StartDate.AddMonths(6);
            }
        }

        public Course(int id, string title, StreamType stream, CourseType type, DateTime startDate)
        {
            Id = id;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            Students = new List<Student>();
            Assignments = new List<Assignment>();
            Trainers = new List<Trainer>();
        }

        public void PrintStudents()
        {
            Console.WriteLine($"===== Students of course[{Id}] {Title} =====");

            if (Students.Count == 0)
                Console.WriteLine("There is no student registered to that course.");
            else
            {
                foreach (var student in Students)
                {
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine();
        }

        public void PrintTrainers()
        {
            Console.WriteLine($"===== Trainers of course[{Id}] {Title} =====");
            if (Trainers.Count == 0)
                Console.WriteLine("There is no trainer registered to that course.");
            else
            {
                foreach (var trainer in Trainers)
                {
                    Console.WriteLine(trainer);
                }
            }
            Console.WriteLine();
        }

        public void PrintAssignments()
        {
            Console.WriteLine($"===== Assignments of course[{Id}] {Title} =====\n");
            if (Assignments.Count == 0)
                Console.WriteLine("There are no assignments.");
            else
            {
                foreach (var assignment in Assignments)
                {
                    Console.WriteLine(assignment);
                }
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{$"[{Id}]", -5} {Title}/{Stream}/{Type}  {StartDate.ToString("yyyy/MM/dd")}-{EndDate.ToString("yyyy/MM/dd")}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Course)
                return Id == ((Course)obj).Id;
            return false;
        }

        public static Course GetRandomCourse(int id, List<string> courseTitles, Random random)
        {
            string title = courseTitles[random.Next(courseTitles.Count)];
            StreamType stream = (StreamType)random.Next(2);
            CourseType type = (CourseType)random.Next(2);
            DateTime startDate = Randomizer.GenerateDateExcludingWeekends(DateTime.Now, 120, random);
            return new Course(id, title, stream, type, startDate);
        }

        public void CreateRandomAssignment(List<string> assignmentDescriptions, Random random)
        {
            var assignmentTitle = $"Assignment{Assignments.Count + 1}";
            var assignmentDescription = assignmentDescriptions[random.Next(assignmentDescriptions.Count)];
            var assignmentSubmissionDateAndTime = Randomizer.GenerateDateExcludingWeekends(StartDate, (EndDate - StartDate).Days, random);
            var courseAssignment = new Assignment(assignmentTitle, assignmentDescription, assignmentSubmissionDateAndTime, this);
            Assignments.Add(courseAssignment);
            CreatePersonalAssignmentsForAllStudentsAppliedToCourse(courseAssignment);
        }

        public void CreatePersonalAssignmentsForAllStudentsAppliedToCourse(Assignment newCourseAssignment)
        {
            foreach (var student in Students)
            {
                var studentAssignmentTitle = newCourseAssignment.Title;
                var studentAssignmentDescription = newCourseAssignment.Description;
                var studentAssignmentSubmissionDateAndTime = newCourseAssignment.SubmissionDateAndTime;
                var course = newCourseAssignment.Course;
                StudentAssignment studentAssignment = new StudentAssignment(studentAssignmentTitle, studentAssignmentDescription, studentAssignmentSubmissionDateAndTime, this);
                student.PersonalAssignments.Add(studentAssignment);
            }
        }

        public void CreatePersonalAssigmentsForStudent(Student newStudent)
        {
            foreach (var assignment in Assignments)
            {
                var studentAssignmentTitle = assignment.Title;
                var studentAssignmentDescription = assignment.Description;
                var studentAssignmentSubmissionDateAndTime = assignment.SubmissionDateAndTime;
                StudentAssignment studentAssignment = new StudentAssignment(studentAssignmentTitle, studentAssignmentDescription, studentAssignmentSubmissionDateAndTime, this);
                newStudent.PersonalAssignments.Add(studentAssignment);
            }
        }

        public static bool NonOverlappingIntervalBetweenTwoCoursesIsMoreThanOneMonth(Course course1, Course course2)
        {
            if (course1 == null)
                throw new ArgumentNullException("course1");
            if (course2 == null)
                throw new ArgumentNullException("course2");
            var interval = Math.Abs((course1.StartDate - course2.StartDate).Days);
            return interval > 30 ? true : false;
        }
    }
}
