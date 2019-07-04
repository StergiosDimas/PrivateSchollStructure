using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class StudentAssignment : Assignment
    {
        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        public StudentAssignment(string title, string description, DateTime submissionDateAndTime, Course course) : base(title, description, submissionDateAndTime, course)
        {

        }

        public static void SetTotalMarkOfAssignmentToRandomValue(StudentAssignment studentAssignment, Random random)
        {
            studentAssignment.TotalMark = random.Next(1, 101);
        }

        public static void SetTotalMarkOfAssignmentsToRandomValues(List<StudentAssignment> studentAssignments, Random random)
        {
            if (studentAssignments == null)
                throw new ArgumentNullException("studentAssignments");
            if (studentAssignments.Count == 0)
                throw new InvalidOperationException("Argument studentAssignments is empty.");
            foreach (var studentAssignment in studentAssignments)
            {
                SetTotalMarkOfAssignmentToRandomValue(studentAssignment, random);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTotalMark: {TotalMark} OralMark: {OralMark}";
        }
    }
}
