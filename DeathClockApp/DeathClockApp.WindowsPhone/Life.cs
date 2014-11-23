using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathClockApp
{
    class Life
    {
        private const uint lifeExpectancy = 85;
        private const uint tabacoDamage = 3;
        private const uint alchoholDamage = 2;


        public Life()
        {
            
        }

        public uint CalculateTimeToTheEnd(string age, bool usesTabaco, bool usesAlchohol)
        {
            uint ageAsInt =0;
            uint.TryParse(age, out ageAsInt);

            uint yearsLeft = lifeExpectancy - ageAsInt;

            if (usesTabaco)
            {
                yearsLeft -= tabacoDamage;
            }

            if (usesAlchohol)
            {
                yearsLeft -= alchoholDamage;
            }
            uint days = 365;
            uint hours = 24;
            uint seconds = 60;
           
            return yearsLeft * days * hours * seconds;
        }
    }
}
