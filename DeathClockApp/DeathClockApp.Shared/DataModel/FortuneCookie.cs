using System;
using System.Collections.Generic;
using System.Text;

namespace DeathClockApp.DataModel
{
   
   public class FortuneCookie
    {
       public FortuneCookie()
       {

       }
       public FortuneCookie(string content, string author)
       {
           this.Content = content;
           this.Author = author;
       }

        public string Content {get; set; }
       
       
       public string Author {get; set;}
           }
}
