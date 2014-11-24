using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DeathClockApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SoundPlayer sp;

        public MainPage()
        {
            this.InitializeComponent();
            this.sp = new SoundPlayer();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            sp.PlayMedia("ms-appx:///sounds/welcome.mp3");
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nfi = new NumberFormatInfo
            {
                NumberDecimalSeparator = ","
            };
            
            if (double.Parse(ageTextBox.Text, nfi) > 120)
            {
                ShowMessageBox("You are not a human ...", "Warning");
            }
            else if (ageTextBox.Text != string.Empty)
            {
                sp.PlayMedia("ms-appx:///sounds/door.mp3");
                Frame.Navigate(typeof(QuestionPage), ageTextBox.Text);
            }
            else
            {
                ShowMessageBox("This will cost you 1 year ...", "Warning");
            }
           
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
    }
}
