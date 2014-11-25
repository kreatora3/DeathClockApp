using System;
using System.Collections.Generic;
using System.Text;

namespace DeathClockApp.DataModel
{
    public class ListOfQuestions
    {


        public IList<Question> Questions
        {
            get
            {
                return new List<Question>() { 
                 new Question("Do you smoke"), 
                 new Question("Do you drink"), 
                 new Question("Do you sport"),
                 new Question("Do you like junk food") };
            }
        }
    }
}
