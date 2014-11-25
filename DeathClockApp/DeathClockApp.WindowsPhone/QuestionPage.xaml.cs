using DeathClockApp.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DeathClockApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
      
        private SoundPlayer sp;
        private Life life;
        private string age;
        private Question currentQuestion;
        private int currentIndex;
        private ListOfQuestions questions;
        private int lifeDeduction;
        private int lifeExpectancy;
        
        // pravq si pole list ot Questions  <-- ako ne e statichen si pravq pole <---
        // promenliva Question currentQuestion;
        // int currentIndex = 0;
        // metod za buton next question => pri klik currentIndex++ 
        // if( currentIndex < listofQuestion.Count()){ currentQuestion = listofquestons[cyrrentindex]

        public QuestionPage()
        {
            this.InitializeComponent();
            this.sp = new SoundPlayer();
            this.life = new Life();
            this.currentIndex = 0;
            this.currentQuestion = new Question(string.Empty);
            this.questions = new ListOfQuestions();
            this.lifeDeduction = 2;
            this.lifeExpectancy = 1;
            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected  override void OnNavigatedTo(NavigationEventArgs e)
        {
            age = e.Parameter.ToString();
            headerTextBlock.Text = "So you are ... " + age + " years old";
            currentQuestion = questions.Questions[this.currentIndex];
            QuestionContainer.Text = currentQuestion.Content;
            YesBtn.Content = YesBtnAnswer(currentIndex);
            this.currentIndex++;
        }

        private void ShowMessageBox(string message, string title)
        {
            MessageDialog msgDialog = new MessageDialog(message, title);

            //OK Button
            UICommand okBtn = new UICommand("OK");
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            //UICommand cancelBtn = new UICommand("Cancel");           
            //msgDialog.Commands.Add(cancelBtn);

            msgDialog.ShowAsync();
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.currentIndex < 4)
            {
                currentQuestion = questions.Questions[this.currentIndex];
                YesBtn.Content = YesBtnAnswer(currentIndex);
                QuestionContainer.Text = currentQuestion.Content;

                this.currentIndex++;
               // age += lifeDeduction;
            }
            else
            {
                long secondsToDisplay = life.CalculateTimeToTheEnd(age);

                sp.PlayMedia("ms-appx:///sounds/laugh.mp3");
                Frame.Navigate(typeof(CountdownPage), secondsToDisplay);
            }
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentIndex < 4)
            {
                currentQuestion = questions.Questions[this.currentIndex];
                YesBtn.Content = YesBtnAnswer(currentIndex);
                QuestionContainer.Text = currentQuestion.Content;
                this.currentIndex++;
               // age -= lifeExpectancy;
            }
            else
            {
                long secondsToDisplay = life.CalculateTimeToTheEnd(age);

                sp.PlayMedia("ms-appx:///sounds/laugh.mp3");
                Frame.Navigate(typeof(CountdownPage), secondsToDisplay);
            }
        }

        private string YesBtnAnswer(int index)
        {
            switch (index)
            {
                case 0: return "I smoke";
                case 1: return "I drink";
                case 2: return "I do";
                case 3: return "Love it";
                default: return "Yes";
            }
                    
        }
    }
}
