using System;
using System.Collections.Generic;
using System.Text;

namespace DeathClockApp.DataModel
{
    public class ListOfFortuneCookies
    {
        public IList<FortuneCookie> Cookies
        {
            get
            {
                return new List<FortuneCookie>() { 
                 new FortuneCookie("People aren’t against you; they are for themselves.", "Unknown"), 
                 new FortuneCookie("Climb mountains not so the world can see you, but so you can see the world.", "Unknown"), 
                 new FortuneCookie("You learn more from failure than from success; don’t let it stop you. Failure builds character.", "Unknown"),
                new FortuneCookie("The most dangerous risk of all – The risk of spending your life not doing what you want on the bet you can buy yourself the freedom to do it later", "Unknown"),
                new FortuneCookie("Go where you’re celebrated, not where you’re tolerated.", "Unknown"),
                new FortuneCookie("The person that you will spend the most time with in your life is yourself, so you better try to make yourself as interesting as possible.", "Unknown"),
                new FortuneCookie("If you accept your limitations you go beyond them.", "Unknown"),
                new FortuneCookie("People often say that motivation doesn’t last. Well, neither does bathing.. that’s why we recommend it daily.", "Unknown"),
                new FortuneCookie("Everyone you meet is afraid of something, loves something, and has lost something", "Unknown"),
                new FortuneCookie("Comfort is the enemy of achievement.", "Unknown"),
                };
            }
        }
    }
}
