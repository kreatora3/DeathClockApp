using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DeathClockApp.DataModel;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using System.Threading.Tasks;
using DeathClockApp.Utils;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DeathClockApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EmailPage : Page
    {
        object mainPageAge;
        NotificationHelper dialog;
        Users user = new Users();
        EmailValidator validator;
        
        public EmailPage()
        {
            this.InitializeComponent();
            this.dialog = new NotificationHelper();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             mainPageAge = e.Parameter;
             validator = new EmailValidator();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = validator.IsValidEmail(emailInputField.Text);
            if (isValid)
            {
                ring.IsActive = true;
                Geoposition position = await GetLocation();

                user.Latitude = position.Coordinate.Latitude;
                user.Longtitude = position.Coordinate.Longitude;
                user.Email = emailInputField.Text;
                await user.SaveAsync();

                Frame.Navigate(typeof(QuestionPage), mainPageAge);
            }
            else
            {
                dialog.ShowMessageBox("Provide valid mail", "Please");
            }
        }

        private async Task<Geoposition> GetLocation()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 5;

            try
            {
                Geoposition geoposition = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromMinutes(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );
                return geoposition;
                
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    dialog.ShowMessageBox("Location service unavailable", "Location confirmation");                  
                }
            }
            return null;
        }
    }
}
