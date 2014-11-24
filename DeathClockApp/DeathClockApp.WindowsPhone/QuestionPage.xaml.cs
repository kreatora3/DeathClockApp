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

        public QuestionPage()
        {
            this.InitializeComponent();
            this.sp = new SoundPlayer();
            this.life = new Life();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isTabacoUser = false;
            bool isAlchohilUser = false;

            var btnDrinkingYes = QuestionPageGrid.Children.OfType<RadioButton>().FirstOrDefault(b => b.Name == "drinkingYes");
            var btnDrinkingNo = QuestionPageGrid.Children.OfType<RadioButton>().FirstOrDefault(b => b.Name ==  "drinkingNo");
            var btnTabacoYes = QuestionPageGrid.Children.OfType<RadioButton>().FirstOrDefault(b => b.Name == "tabacoYes");
            var btnTabacoNo = QuestionPageGrid.Children.OfType<RadioButton>().FirstOrDefault(b => b.Name == "tabacoNo");
            
            if (btnDrinkingYes.IsChecked == true)
            {
                isAlchohilUser = true;
            }

            if (btnTabacoYes.IsChecked == true)
            {
                isTabacoUser = true;
            }

            if (btnDrinkingYes.IsChecked != true && btnDrinkingNo.IsChecked != true)
            {
                ShowMessageBox("Make sure you've answered both questions", "Warning");
            }
            else if (btnTabacoYes.IsChecked != true && btnTabacoNo.IsChecked != true)
            {
                ShowMessageBox("Make sure you've answered both questions", "Warning");
            }
            else
            {
                long secondsToDisplay = life.CalculateTimeToTheEnd(age, isAlchohilUser, isTabacoUser);

                sp.PlayMedia("ms-appx:///sounds/laugh.mp3");
                Frame.Navigate(typeof(CountdownPage), secondsToDisplay);
            }
           
           
        }

      

       
    }
}
