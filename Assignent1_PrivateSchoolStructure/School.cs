using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignent1_PrivateSchoolStructure
{
    public class School
    {
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public List<Trainer> Trainers { get; set; }

        public School()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
            Trainers = new List<Trainer>();
        }

        // Course Methods
        public void CreateCourseFromUserInput(string courseInfo, Random random)
        {
            var courseTitle = String.Empty;
            StreamType courseStream;
            CourseType courseType;
            DateTime courseStartDate = DateTime.MinValue;

            if (String.IsNullOrWhiteSpace(courseInfo))
                throw new InvalidOperationException("You must enter course Title, Stream type , Type  and Start date separated by komma.");
            string[] courseProps = courseInfo.Split(',');
            if (courseProps.Length != 4)
                throw new InvalidOperationException("You must enter course Title, Stream type , Type  and Start date separated by komma.");
            if (String.IsNullOrWhiteSpace(courseProps[0]))
                throw new InvalidOperationException("Course title cannot be empty.");
            courseTitle = courseProps[0];
            if (!Enum.TryParse<StreamType>(courseProps[1], true, out courseStream))
                throw new InvalidOperationException("You entered a not valid course stream type.");
            if (!Enum.TryParse<CourseType>(courseProps[2], true, out courseType))
                throw new InvalidOperationException("You entered a not valid course type.");
            if (!DateTime.TryParse(courseProps[3], out courseStartDate))
                throw new InvalidOperationException("You entered a not valid course Start date.");
            AddCourse(courseTitle, courseStream, courseType, courseStartDate, random);
        }

        public void AddCourse(string title, StreamType stream, CourseType type, DateTime startDate, Random random)
        {
            int id = GetRandomUniqueCourseId(random);
            var course = new Course(id, title, stream, type, startDate);
            Courses.Add(course);
            Console.WriteLine($"Created course {course}");
        }

        public void AddRandomCourses(List<string> courseTitles, int numberOfCourses, Random random)
        {

            Course randomCourse = null;
            for (int i = 0; i < numberOfCourses; i++)
            {
                if (Courses.Count == 200)
                    throw new InvalidOperationException("Max number of courses: 200");
                randomCourse = GetRandomUniqueCourse(courseTitles, random);
                Courses.Add(randomCourse);
                Console.WriteLine($"Created course {randomCourse}");
            }
        }

        public Course GetRandomUniqueCourse(List<string> courseTitles, Random random)
        {
            int randomId = GetRandomUniqueCourseId(random);
            return Course.GetRandomCourse(randomId, courseTitles, random);
        }


        // Students Methods
        public void CreateStudent(string firstName, string lastName, DateTime dateOfBirth, Random random)
        {
            int id = GetRandomUniqueStudentId(random);
            var student = new Student(id, firstName, lastName, dateOfBirth);
            Students.Add(student);
            Console.WriteLine($"Student registered: {student}");
        }

        public void CreateStudentFromUserInput(string studentInfo, Random random)
        {
            var studentFirstName = String.Empty;
            var studentLastName = String.Empty;
            var studentBirthDate = DateTime.MinValue;

            if (String.IsNullOrWhiteSpace(studentInfo))
                throw new InvalidOperationException("You must enter student FirstName, LastName and BirthDate separated by komma.");
            var studentProps = studentInfo.Split(',');
            if (studentProps.Length != 3)
                throw new InvalidOperationException("You must enter student FirstName, LastName and BirthDate separated by komma.");
            if (String.IsNullOrWhiteSpace(studentProps[0]) || String.IsNullOrWhiteSpace(studentProps[1]))
                throw new InvalidOperationException("Both FirstName and LastName cannot be empty.");
            studentFirstName = studentProps[0];
            studentLastName = studentProps[1];
            if (!DateTime.TryParse(studentProps[2], out studentBirthDate))
                throw new InvalidOperationException("You must enter a valid date.");
            CreateStudent(studentFirstName, studentLastName, studentBirthDate, random);
        }

        public void AssignStudentToACourse(int studentId, int courseId)
        {
            var student = GetStudent(studentId);
            var course = GetCourse(courseId);
            if (course.Students.Contains(student))
                throw new InvalidOperationException($"Student[{student.Id}] is already assigned to course[{course.Id} {course.Title}]");
            course.Students.Add(student);
            student.Courses.Add(course);
            Console.WriteLine($"[{student.Id}]{student.FullName} enrolled in course[{course.Id}]{course.Title}");
            course.CreatePersonalAssigmentsForStudent(student);
        }

        public Student GetRandomUniqueStudent(List<string> firstNames, List<string> lastNames, Random random)
        {
            int randomId = GetRandomUniqueStudentId(random);
            return Student.GetRandomStudent(randomId, firstNames, lastNames, random);
        }

        public void AddRandomStudents(List<string> firstNames, List<string> lastNames, int numberOfStudents, Random random)
        {
            Student randomStudent = null;
            for (int i = 0; i < numberOfStudents; i++)
            {
                if (Students.Count == 200)
                    throw new InvalidOperationException("Max number of students: 200");
                randomStudent = GetRandomUniqueStudent(firstNames, lastNames, random);
                Students.Add(randomStudent);
                Console.WriteLine($"Student registered: {randomStudent}");
            }
        }

        public void RandomlyAssignStudentsToAllCourses(Random random)
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                AssignRandomNumberOfStudentsToACourse(course.Id, random);
            }
        }

        public void AssignRandomNumberOfStudentsToARandomCourse(Random random)
        {

            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            Course randomCourse = Courses[random.Next(Courses.Count)];
            AssignRandomNumberOfStudentsToACourse(randomCourse.Id, random);

            //List<Student> studentsThatAreNotAssignedToRandomCourse = Students.FindAll(x => !x.Courses.Contains(randomCourse));

            //if (studentsThatAreNotAssignedToRandomCourse.Count == 0)
            //    throw new InvalidOperationException($"All registered students have applied to course [{randomCourse.Id}]{randomCourse.Title}");

            //int numberOfStudentsToAssign = random.Next(1, studentsThatAreNotAssignedToRandomCourse.Count + 1);
            //for (int i = 0; i < numberOfStudentsToAssign; i++)
            //{
            //    var studentToAssign = studentsThatAreNotAssignedToRandomCourse[random.Next(studentsThatAreNotAssignedToRandomCourse.Count)];
            //    randomCourse.Students.Add(studentToAssign);
            //    randomCourse.CreatePersonalAssigmentsForStudent(studentToAssign);
            //    studentToAssign.Courses.Add(randomCourse);
            //    studentsThatAreNotAssignedToRandomCourse.Remove(studentToAssign);
            //}
            //Console.WriteLine($"Added {numberOfStudentsToAssign} students to course {randomCourse}");
        }

        public void AssignRandomNumberOfStudentsToACourse(int courseId, Random random)
        {
            var course = GetCourse(courseId);
            if (Students.Count == 0)
                throw new InvalidOperationException("There are no registered students.");

            List<Student> studentsThatAreNotAssignedToCourse = Students.FindAll(x => !x.Courses.Contains(course));

            if (studentsThatAreNotAssignedToCourse.Count == 0)
                throw new InvalidOperationException($"All registered students have applied to course [{course.Id}]{course.Title}");

            int numberOfStudentsToAssign = random.Next(1, studentsThatAreNotAssignedToCourse.Count + 1);
            for (int i = 0; i < numberOfStudentsToAssign; i++)
            {
                var studentToAssign = studentsThatAreNotAssignedToCourse[random.Next(studentsThatAreNotAssignedToCourse.Count)];
                course.Students.Add(studentToAssign);
                course.CreatePersonalAssigmentsForStudent(studentToAssign);
                studentToAssign.Courses.Add(course);
                studentsThatAreNotAssignedToCourse.Remove(studentToAssign);
            }
            Console.WriteLine($"Added {numberOfStudentsToAssign} students to course {course}");
        }


        public List<Student> GetStudentsPerCourse(int courseId)
        {
            var course = GetCourse(courseId);
            if (course.Students.Count == 0)
                throw new InvalidOperationException($"There are no registered students in course wit id {courseId}.");
            return course.Students;
        }

        private bool StudentBelongsToMoreThanOneCourse(Student student)
        {
            if (student == null || student.Courses.Count <= 1)
                return false;
            return true;
        }

        // Trainer methods
        public void CreateTrainerFromUserInput(string trainerInfo, Random random)
        {
            var trainerFirstname = String.Empty;
            var trainerLastName = String.Empty;
            var trainerSubject = String.Empty;
            if (String.IsNullOrWhiteSpace(trainerInfo))
                throw new InvalidOperationException("You must enter trainer's FirstName, LastName and Subject separated by komma.");
            var trainerProps = trainerInfo.Split(',');
            if (trainerProps.Length != 3)
                throw new InvalidOperationException("You must enter trainer's FirstName, LastName and Subject separated by komma.");
            if (String.IsNullOrWhiteSpace(trainerProps[0]) || String.IsNullOrWhiteSpace(trainerProps[1]) || String.IsNullOrWhiteSpace(trainerProps[2]))
                throw new InvalidOperationException("FirstName,LastName and Subject cannot be empty.");
            trainerFirstname = trainerProps[0];
            trainerLastName = trainerProps[1];
            trainerSubject = trainerProps[2];
            AddTrainer(trainerFirstname, trainerLastName, trainerSubject, random);
        }

        public void AddTrainer(string firstName, string lastName, string subject, Random random)
        {
            int id = GetRandomUniqueTrainerId(random);
            var trainer = new Trainer(id, firstName, lastName, subject);
            Trainers.Add(trainer);
            Console.WriteLine($"Registered trainer: {trainer}");
        }

        public Trainer GetRandomUniqueTrainer(List<string> firstNames, List<string> lastNames, List<string> trainerSubjects, Random random)
        {
            int randomId = GetRandomUniqueTrainerId(random);
            return Trainer.GetRandomTrainer(randomId, firstNames, lastNames, trainerSubjects, random);
        }

        public void AddRandomTrainers(List<string> firstNames, List<string> lastNames, List<string> trainerSubjects, int numberOfTrainers, Random random)
        {
            Trainer randomTrainer = null;
            for (int i = 0; i < numberOfTrainers; i++)
            {
                if (Trainers.Count == 200)
                    throw new InvalidOperationException("Max number of trainers: 200");
                randomTrainer = GetRandomUniqueTrainer(firstNames, lastNames, trainerSubjects, random);
                Trainers.Add(randomTrainer);
                Console.WriteLine($"Trainer registered: {randomTrainer}");
            }
        }

        public void AssignTrainerToCourse(int trainerId, int courseId)
        {
            var trainer = GetTrainer(trainerId);
            var course = GetCourse(courseId);

            if (course.Trainers.Contains(trainer))
                throw new InvalidOperationException($"{trainer} is already assigned to {course}");

            foreach (var trainerCourse in trainer.Courses)
            {
                if (!Course.NonOverlappingIntervalBetweenTwoCoursesIsMoreThanOneMonth(trainerCourse, course))
                    throw new InvalidOperationException($"Non overlapping interval between course[{courseId}] and course[{trainerCourse.Id}] is lower or equal to a month.");
            }

            course.Trainers.Add(trainer);
            trainer.Courses.Add(course);
            Console.WriteLine($"Trainer[{trainer.Id}] {trainer.FullName} assigned to course[{courseId}] {course.Title}");
        }

        public void RandomlyAssignTrainersToAllCourses(Random random)
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                AssignRandomNumberOfTrainersToACourse(course.Id, random);
            }
        }

        public void AssignRandomNumberOfTrainersToACourse(int courseId, Random random)
        {
            var course = GetCourse(courseId);
            if (Trainers.Count == 0)
                throw new InvalidOperationException("There are no registered trainers.");

            var trainersThatAreNotAssignedToRandomCourse = Trainers.FindAll(x => !x.Courses.Contains(course));

            if (trainersThatAreNotAssignedToRandomCourse.Count == 0)
                throw new InvalidOperationException($"All trainers are assigned to: {course}");

            int numberOfTrainersToAssign = random.Next(1, trainersThatAreNotAssignedToRandomCourse.Count + 1);
            for (int i = 0; i < numberOfTrainersToAssign; i++)
            {
                var randomTrainer = trainersThatAreNotAssignedToRandomCourse[random.Next(trainersThatAreNotAssignedToRandomCourse.Count)];
                course.Trainers.Add(randomTrainer);
                randomTrainer.Courses.Add(course);
                trainersThatAreNotAssignedToRandomCourse.Remove(randomTrainer);
            }
            Console.WriteLine($"Assigned {numberOfTrainersToAssign} trainers to course {course}");
        }

        public void AssignRandomNumberOfTrainersToARandomCourse(Random random)
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");

            var randomCourse = Courses[random.Next(Courses.Count)];
            AssignRandomNumberOfTrainersToACourse(randomCourse.Id, random);
        }

        // Assignments methods
        public List<Assignment> GetAssignmentsPerCourse(int courseId)
        {
            var course = GetCourse(courseId);
            if (course.Assignments.Count == 0)
                throw new InvalidOperationException($"Course[{courseId}] has no assignments.");
            return course.Assignments;
        }

        public List<StudentAssignment> GetAllStudentAssignmentsForACourse(int courseId)
        {
            var course = GetCourse(courseId);
            var listOfAllStudentAssignments = new List<StudentAssignment>();
            if (course.Assignments.Count == 0)
                throw new InvalidOperationException($"Course[{course.Id}] has no assignments.");
            if (course.Students.Count == 0)
                throw new InvalidOperationException($"Course[{course.Id} has no students.");
            foreach (var student in course.Students)
            {
                listOfAllStudentAssignments.AddRange(student.PersonalAssignments.FindAll(x => x.Course.Equals(course)));
            }
            return listOfAllStudentAssignments;
        }

        public List<StudentAssignment> GetAllAssignmentsPerStudent(int studentId)
        {
            var student = GetStudent(studentId);
            if (student.PersonalAssignments.Count == 0)
                throw new InvalidOperationException($"Student with id[{studentId}] has no assignments.");
            return student.PersonalAssignments;
        }

        public void SetRandomTotalMarkToAllStudentsAssignments(Random random)
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                StudentAssignment.SetTotalMarkOfAssignmentsToRandomValues(GetAllStudentAssignmentsForACourse(course.Id), random);
            }
        }

        public void SetRandomMarkToAllStudentsAssignmetsOfACourse(int courseId, Random random)
        {
            StudentAssignment.SetTotalMarkOfAssignmentsToRandomValues(GetAllStudentAssignmentsForACourse(courseId), random);

        }

        public void AddRandomAssignmentsToACourse(int courseId, int numberOfAssignments, List<string> assignmentDescriptions, Random random)
        {
            if (numberOfAssignments < 0)
                throw new InvalidOperationException("Number of assignments must greater or equal to zero.");
            for (int i = 0; i < numberOfAssignments; i++)
            {
                CreateRandomAssignment(courseId, assignmentDescriptions, random);
            }

        }

        public void AddRandomNumberOfAssignmetsToAllCourses(int maxNumberOfAssignments, List<string> assignmentDescriptions, Random random)
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                AddRandomAssignmentsToACourse(course.Id, random.Next(1, maxNumberOfAssignments + 1), assignmentDescriptions, random);
            }
        }

        public void CreateRandomAssignment(int courseId, List<string> assignmentDescriptions, Random random)
        {
            var course = GetCourse(courseId);
            var assignmentTitle = $"Assignment{course.Assignments.Count + 1}";
            var assignmentDescription = assignmentDescriptions[random.Next(assignmentDescriptions.Count)];
            var assignmentSubmissionDateAndTime = Randomizer.GenerateDateExcludingWeekends(course.StartDate, (course.EndDate - course.StartDate).Days, random);
            var courseAssignment = new Assignment(assignmentTitle, assignmentDescription, assignmentSubmissionDateAndTime, course);
            course.Assignments.Add(courseAssignment);
            course.CreatePersonalAssignmentsForAllStudentsAppliedToCourse(courseAssignment);
            Console.WriteLine($"Created {courseAssignment}");
        }

        public void CreateAssignmentFromUserInput(string assignmnetInfo, int courseId)
        {
            var course = GetCourse(courseId);
            if (String.IsNullOrWhiteSpace(assignmnetInfo))
                throw new InvalidOperationException("You must enter Description and Submission DateAndTime separated by komma");
            var assignmenProps = assignmnetInfo.Split(',');
            if (assignmenProps.Length != 2)
                throw new InvalidOperationException("You must enter Description and Submission DateAndTime separated by komma");
            var description = assignmenProps[0];
            var submissionDateAndTime = DateTime.MinValue;
            if (!DateTime.TryParse(assignmenProps[1], out submissionDateAndTime))
                throw new InvalidOperationException("You must enter a valid date and time");
            var title = $"Assignment{course.Assignments.Count + 1}";
            var assignment = new Assignment(title, description, submissionDateAndTime, course);
            course.Assignments.Add(assignment);
            course.CreatePersonalAssignmentsForAllStudentsAppliedToCourse(assignment);
            Console.WriteLine($"Created: {assignment}");
        }

        // Printing Methods
        public void PrintStudentsThatNeedToSubmitAssigmentsInTheSpecifiedWeek(DateTime date, CultureInfo myCI)
        {
            var monday = FirstDateOfWeek(date, myCI);
            var friday = monday.AddDays(4);
            Console.WriteLine($"===== Students that need to submit assignments from {monday.ToString("yyyy/MM/dd")} to {friday.ToString("yyyy/MM/dd")}");
            foreach (var student in Students)
            {
                if (student.PersonalAssignments.Count > 0 && student.PersonalAssignments.Exists(x => (x.SubmissionDateAndTime >= monday && x.SubmissionDateAndTime <= friday)))
                    Console.WriteLine(student);
            }
        }

        public void PrintStudentsThatBelongToMoreThanOneCourse()
        {
            Console.WriteLine("===== Students tha belong to more than one course =====");
            if (Students.Count == 0)
                Console.WriteLine("There are no registered students.");
            else
            {
                var students = new List<Student>();
                foreach (var student in Students)
                {
                    if (StudentBelongsToMoreThanOneCourse(student))
                        Console.WriteLine(student);
                }
            }
        }

        public void PrintAssignmentsPerStudent(int studentId)
        {
            var student = GetStudent(studentId);
            student.PrintStudentAssignments();
        }

        public void PrintAllAssignmentsPerStudent()
        {
            if (Students.Count == 0)
                Console.WriteLine("There are no registered students.");
            else
            {
                Console.WriteLine("===== All assignments per student =====\n");
                foreach (var student in Students)
                {
                    Console.WriteLine($"=====[{student.Id}] {student.FullName} assignments");
                    if (student.PersonalAssignments.Count == 0)
                    {
                        Console.WriteLine($"Student[{student.Id}] has no assignments.");
                        Console.WriteLine();
                    }
                    else
                    {
                        foreach (var studentAssignment in student.PersonalAssignments)
                        {
                            Console.WriteLine(studentAssignment);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        private void PrintAllStudentAssignmentsOfACourse(Course course)
        {
            if (course == null)
                throw new NullReferenceException("course");
            Console.WriteLine($"===== Student Assignments of Course[{course.Id}] {course.Title} =====\n");
            if (course.Assignments.Count == 0)
                Console.WriteLine($"Course[{course.Id}] has no assignments.");
            else if (course.Students.Count == 0)
            {
                Console.WriteLine($"Course[{course.Id} has no students.");
            }
            else
            {
                foreach (var student in course.Students)
                {
                    student.PrintStudentAssignmentsRelatedToACourse(course);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        public void PrintAllStudentAssignmentsForAllCourses()
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                try
                {
                    PrintAllStudentAssignmentsOfACourse(course);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }

        public void PrintAssignmentsForAllCourses()
        {
            if (Courses.Count == 0)
                throw new InvalidOperationException("There are no registered courses.");
            foreach (var course in Courses)
            {
                course.PrintAssignments();
            }
        }

        public void PrintStudentsForAllCourses()
        {
            Console.WriteLine("===== Students per course =====\n");
            if (Courses.Count == 0)
                Console.WriteLine("There are no registered courses.");
            else
            {
                foreach (var course in Courses)
                {
                    course.PrintStudents();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        public void PrintTrainersForAllCourses()
        {
            Console.WriteLine("===== Trainers per course =====\n");
            if (Courses.Count == 0)
                Console.WriteLine("There are no registered courses.");
            else
            {
                foreach (var course in Courses)
                {
                    course.PrintTrainers();
                }
            }
            Console.WriteLine();
        }

        public void PrintAllCourses()
        {
            Console.WriteLine("===== Courses =====");
            if (Courses.Count == 0)
                Console.WriteLine("There are no registered courses.");
            else
            {
                foreach (var course in Courses)
                {
                    Console.WriteLine(course);
                }
                Console.WriteLine($"Total courses: {Courses.Count}");
            }

            Console.WriteLine();
        }

        public void PrintAllCoursesLite()
        {
            Console.WriteLine("===== Courses =====");
            if (Courses.Count == 0)
                Console.WriteLine("There are no registered courses.");
            else
                foreach (var course in Courses)
                {
                    Console.WriteLine($"[{course.Id}] {course.Title}");
                }
            Console.WriteLine();
        }

        public void PrintAllStudents()
        {
            Console.WriteLine("===== Students =====");
            if (Students.Count == 0)
                Console.WriteLine("There are no registered students.");
            else
            {
                foreach (var student in Students)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine($"Total students: {Students.Count}");
            }
            Console.WriteLine();
        }

        public void PrintAllStudentsLite()
        {
            Console.WriteLine("===== Students =====");
            if (Students.Count == 0)
                Console.WriteLine("There are no registered students.");
            else
                foreach (var student in Students)
                {
                    Console.WriteLine($"[{student.Id}] {student.FullName}");
                }
            Console.WriteLine();
        }

        public void PrintAllTrainers()
        {
            Console.WriteLine("===== Trainers =====");
            if (Trainers.Count == 0)
                Console.WriteLine("There are no registered trainers.");
            else
            {
                foreach (var trainer in Trainers)
                {
                    Console.WriteLine(trainer);
                }
                Console.WriteLine($"Total trainers: {Trainers.Count}");
            }
            Console.WriteLine();
        }

        public Trainer GetTrainer(int trainerId)
        {
            var trainer = Trainers.Find(x => x.Id == trainerId);
            if (trainer == null)
                throw new InvalidOperationException($"Trainer with id {trainerId} could not be found.");
            return trainer;
        }

        public Course GetCourse(int courseId)
        {
            var course = Courses.Find(x => x.Id == courseId);
            if (course == null)
                throw new InvalidOperationException($"Course with id {courseId} could not be found.");
            return course;
        }

        public Student GetStudent(int studentId)
        {
            var student = Students.Find(x => x.Id == studentId);
            if (student == null)
                throw new InvalidOperationException($"Student with id {studentId} could not be found.");
            return student;

        }

        public int GetRandomUniqueCourseId(Random random)
        {
            int randomId = 0;
            do
            {
                randomId = random.Next(1, 201);
            } while (Courses.Exists(x => x.Id == randomId));
            return randomId;
        }

        public int GetRandomUniqueStudentId(Random random)
        {
            int randomId = 0;
            do
            {
                randomId = random.Next(1, 201);
            } while (Students.Exists(x => x.Id == randomId));
            return randomId;
        }

        public int GetRandomUniqueTrainerId(Random random)
        {
            int randomId = 0;
            do
            {
                randomId = random.Next(1, 201);
            } while (Trainers.Exists(x => x.Id == randomId));
            return randomId;
        }

        // Special Methods

        public static DateTime FirstDateOfWeek(DateTime date, CultureInfo myCI)
        {
            Calendar myCal = myCI.Calendar;
            DateTime jan1 = new DateTime(2019, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
            DateTime firstThursday = jan1.AddDays(daysOffset);
            int firstWeek = myCal.GetWeekOfYear(firstThursday, myCI.DateTimeFormat.CalendarWeekRule, myCI.DateTimeFormat.FirstDayOfWeek);
            var weekNum = myCal.GetWeekOfYear(date, myCI.DateTimeFormat.CalendarWeekRule, myCI.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek == 1)
                weekNum -= 1;
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        //public void AddRandomCourses(List<string> courseTitles, int numberOfCourses, Random random)
        //{
        //    Course randomCourse = null;
        //    for (int i = 0; i < numberOfCourses; i++)
        //    {
        //        do
        //        {
        //            randomCourse = GetRandomUniqueCourse(courseTitles, random);
        //        } while (!TryAddCourse(randomCourse));
        //    }
        //}
        //public void AssignRandomNumberOfStudentsToARandomCourse(Random random)
        //{
        //    if (Courses.Count == 0 && Students.Count == 0)
        //        throw new InvalidOperationException("Can not proceed. There are no registered students or courses.");
        //    if (Courses.Count == 0)
        //        throw new InvalidOperationException("There is no course to assign students to.");
        //    if (Students.Count == 0)
        //        throw new InvalidOperationException("There is no student to be assigned to a course.");

        //    Course randomCourse = null;
        //    int numberOfStudentsToAssign = random.Next(1, Students.Count + 1);
        //    int counter = 0;
        //    Student student = null;
        //    randomCourse = Courses[random.Next(Courses.Count)];
        //    var randomCourseStudents = randomCourse.Students;

        //    while ((randomCourseStudents.Count < Students.Count) && (counter < numberOfStudentsToAssign))
        //    {
        //        student = Students[random.Next(Students.Count)];
        //        if (!randomCourseStudents.Contains(student))
        //        {
        //            randomCourseStudents.Add(student);
        //            student.Courses.Add(randomCourse);
        //            //Console.WriteLine($"Added: {student}\nto\n{randomCourse}");
        //            counter++;
        //        }
        //        //else
        //        //Console.WriteLine($"Student id: {student.Id} - {student.FullName} is already assigned to\n{randomCourse}");
        //    }
        //    Console.WriteLine($"Added {counter} students to course [{randomCourse.Id}]{randomCourse.Title} - Students: {randomCourse.Students.Count}\n");
        //}
        // We assume we cannot add a course with the same title,stream and type
        //private bool TryAddCourse(Course course)
        //{
        //    if (course == null)
        //        throw new ArgumentNullException("course");
        //    if (!Courses.Contains(course))
        //    {
        //        Courses.Add(course);
        //        Console.WriteLine($"Course added:\n{course}\n");
        //        return true;
        //    }

        //    //Console.WriteLine($"A course with the same Title({course.Title})/Stream({course.Stream})/Type({course.Type}) has already been added");
        //    return false;
        //}
        //public void AddAssignmentToCourse(Assignment assignment, int courseId)
        //{
        //    var course = Courses.Find(x => x.Id == courseId);
        //    if (course == null)
        //        throw new InvalidOperationException($"Not found course with id {courseId}");

        //    course.Assignments.Add(assignment);
        //}

        //public void AddRandomAssignmentsToARandomCourse(int maxNumberOfAssignments, List<string> assignmentDescriptions, Random random)
        //{
        //    if (Courses.Count == 0)
        //        throw new InvalidOperationException("There are no registered courses.");
        //    var course = Courses[random.Next(Courses.Count)];
        //    var numberOfAssignments = random.Next(1, maxNumberOfAssignments + 1);
        //    AddRandomAssignmentsToACourse(course.Id, numberOfAssignments, assignmentDescriptions, random);
        //}
    }
}
