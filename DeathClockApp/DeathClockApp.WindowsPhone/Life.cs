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
        private const int tabacoDamage = 3;
        private const int alchoholDamage = 2;


        public Life()
        {
            
        }

        public long CalculateTimeToTheEnd(string age, bool usesTabaco, bool usesAlchohol)
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


            if (usesTabaco)
            {
                yearsLeft -= tabacoDamage;
            }

            if (usesAlchohol)
            {
                yearsLeft -= alchoholDamage;
            }

            
            int days = 365;
            int hours = 24;
            int minutes = 60;
            int seconds = 60;
           
            long result = yearsLeft * days * hours * minutes * seconds;

            return result;
        }
    }
}
