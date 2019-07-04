using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double TuitionFees { get; set; }
        public List<Course> Courses { get; set; }

        public List<StudentAssignment> PersonalAssignments { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Student(int id, string firstName, string lastname, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            PersonalAssignments = new List<StudentAssignment>();
            Courses = new List<Course>();
        }

        public Student(int id, string firstName, string lastname, DateTime dateOfBirth, double tuitionFees)
            : this(id, firstName, lastname, dateOfBirth)
        {
            TuitionFees = tuitionFees;
        }

        


        public override string ToString()
        {
            return $"{$"[{Id}]", -5} {FullName} - Date of birth: {DateOfBirth.ToString("yyyy/MM/dd")} - Tuition fees: {TuitionFees}";
        }

        public static void PrintListOfStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj is Student) && (Id == ((Student)obj).Id))
                return true;
            return false;
        }

        public static Student GetRandomStudent(int id, List<string> firstNames, List<string> lastNames, Random random)
        {
            var firstName = firstNames[random.Next(firstNames.Count)];
            var lastName = lastNames[random.Next(lastNames.Count)];
            var dateOfBirth = Randomizer.GenerateDate(new DateTime(1970, 1, 1), 10950, random);
            return new Student(id, firstName, lastName, dateOfBirth);
        }

        public void PrintStudentAssignments()
        {
            Console.WriteLine(this);
            Console.WriteLine("===== Personal Assignments =====");
            if (Courses.Count == 0)
                throw new InvalidOperationException($"Student[{Id}] is not assigned to any course.");
            if (PersonalAssignments.Count == 0)
                throw new InvalidOperationException($"Student[{Id}] has no assignments.");
            foreach (var studentAssignment in PersonalAssignments)
            {
                Console.WriteLine(studentAssignment);
            }
        }

        public void PrintStudentAssignmentsRelatedToACourse(Course course)
        {
            Console.WriteLine(this);
            Console.WriteLine($"===== Personal Assignments related to course[{course.Id} {course.Title}] =====");
            if (Courses.Count == 0)
                throw new InvalidOperationException($"Student[{Id}] is not assigned to any course.");
            if (PersonalAssignments.Count == 0)
                throw new InvalidOperationException($"Student[{Id}] has no assignments.");
            var studentAssignmentsRelatedToTheSpecificCourse = PersonalAssignments.FindAll(x => x.Course.Equals(course));
            if (studentAssignmentsRelatedToTheSpecificCourse.Count == 0)
                throw new InvalidOperationException($"Student[{Id}] has no assignments related to course[{course.Id}] {course.Title}");
            foreach (var studentAssignment in studentAssignmentsRelatedToTheSpecificCourse)
            {
                Console.WriteLine(studentAssignment);
            }
        }

    }
}
