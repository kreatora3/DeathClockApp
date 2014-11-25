namespace DeathClockApp.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DeathClockApp.ViewModel;

    public class Question : ViewModelBase
    {
        private string content;

        public Question(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get 
            { 
                return this.content; 
            }
            set
            { 
                content = value;
                OnPropertyChanged("Content");
            }
        }
        
    }
}
