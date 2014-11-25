using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Parse;
using DeathClockApp.DataModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DeathClockApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FortuneCookiePage : Page
    {
        FortuneCookie cookie;
        ListOfFortuneCookies cookieList;
        public FortuneCookiePage()
        {
            this.InitializeComponent();
            this.cookie = new FortuneCookie();
            cookieList = new ListOfFortuneCookies();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private  void TextBlock_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            cookie = cookieList.Cookies[GetRandom(0, cookieList.Cookies.Count - 1)];
            string text = cookie.Content;
            string author = cookie.Author;
            fortuneCookieTB.Text = text;
            authorTB.Text = "Autor: " + author;
        }

        private int GetRandom(int min, int max)
        {
            int index = 0 ;
            Random rand = new Random();
            index = rand.Next(min, max);
            return index;
        }
    }
}
