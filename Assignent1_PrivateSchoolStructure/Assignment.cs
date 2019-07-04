using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class Assignment
    {
        public string Description { get; set; }
        public DateTime SubmissionDateAndTime { get; set; }
        public Course Course { get; set; }
        public string Title { get; set; }

        public Assignment(string title, string description, DateTime submissionDateAndTime, Course course)
        {
            if (course == null)
                throw new InvalidOperationException("Assignment can not be created without a course.");
            if (submissionDateAndTime <= course.StartDate || submissionDateAndTime > course.EndDate)
                throw new InvalidOperationException("Submission date must be greater than course's starting date and lower or equal than course's end date.");
            if (submissionDateAndTime.DayOfWeek == DayOfWeek.Saturday || submissionDateAndTime.DayOfWeek == DayOfWeek.Sunday)
                throw new InvalidOperationException("Submission day must be in range [Monday...Friday]");
            Title = title;
            Description = description;
            SubmissionDateAndTime = submissionDateAndTime;
            Course = course;
        }

        public override bool Equals(object obj)
        {
            if (obj is Assignment)
            {
                var objAsAssignment = (Assignment)obj;
                return (objAsAssignment.Title == Title) && (objAsAssignment.Description == Description) && (objAsAssignment.Course == Course);
            }
            return false;
        }

        public override string ToString()
        {
            return $"Course[{Course.Id}], {Title}, {Description}, Sub DateAndTime: {SubmissionDateAndTime}";
        }
    }
}
