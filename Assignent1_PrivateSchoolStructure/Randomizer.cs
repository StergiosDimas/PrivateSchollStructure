using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignent1_PrivateSchoolStructure
{
    public class Randomizer
    {
        public static DateTime GenerateDate(DateTime startDate, int range, Random random)
        {
            return startDate.AddDays(random.Next(1, range));
        }

        public static DateTime GenerateDateExcludingWeekends(DateTime startDate, int range, Random random)
        {
            var randomDate = DateTime.Now;
            do
            {
                randomDate = GenerateDate(startDate, range, random);
            } while (randomDate.DayOfWeek == DayOfWeek.Saturday || randomDate.DayOfWeek == DayOfWeek.Sunday);
            return randomDate;
        }
    }
}
