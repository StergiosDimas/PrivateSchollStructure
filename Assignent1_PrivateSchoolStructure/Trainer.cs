using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public List<Course> Courses { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Trainer(int id, string firstName, string lastName, string subject)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
            Courses = new List<Course>();
        }

        public static Trainer GetRandomTrainer(int id, List<string> firstNames, List<string> lastNames, List<string> trainerSubjects, Random random)
        {
            var firstName = firstNames[random.Next(firstNames.Count)];
            var lastName = lastNames[random.Next(lastNames.Count)];
            var subject = trainerSubjects[random.Next(trainerSubjects.Count)];
            return new Trainer(id, firstName, lastName, subject);
        }

        public override string ToString()
        {
            return $"{$"[{Id}]", -5} {FullName} - Subject: {Subject}";
        }

        public override bool Equals(object obj)
        {
            if ((obj is Trainer) && (Id == ((Trainer)obj).Id))
                    return true;
            return false;
        }
    }
}
