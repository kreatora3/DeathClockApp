using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathClockApp
{
    class Life
    {
        private const int maxLifeExpectancy = 120;
        private const int averageLifeExpectancy = 85;

        public Life()
        {
            
        }

        public long CalculateTimeToTheEnd(string age)
        {
            int ageAsInt = 0;
            int personalLifeLimit = 0;
            
            int.TryParse(age, out ageAsInt);

           
            if (ageAsInt > averageLifeExpectancy)
            {
                personalLifeLimit = new Random().Next(ageAsInt, maxLifeExpectancy);
            }
            else
            {
                personalLifeLimit = new Random().Next(averageLifeExpectancy, maxLifeExpectancy);
            }
            int yearsLeft = personalLifeLimit - ageAsInt;

            
            int days = 365;
            int hours = 24;
            int minutes = 60;
            int seconds = 60;
           
            long result = (long)yearsLeft * (long)days * (long)hours * (long)minutes * (long)seconds;

            return result;
        }
    }
}
