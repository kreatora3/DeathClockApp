﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DeathClockApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CountdownPage : Page
    {
        private uint seconds;
        DispatcherTimer dispatch;
       

        public CountdownPage()
        {
            this.InitializeComponent();
            this.dispatch = new DispatcherTimer();
            

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            seconds =(uint)e.Parameter;
        }

        
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (!dispatch.IsEnabled)
            {
                dispatch.Tick += dispatch_Tick;
                dispatch.Interval = new TimeSpan(0, 0, 1);
                dispatch.Start();
            }
        }

        void dispatch_Tick(object sender, object e)
        {
            seconds--;
            countdownTimer.Text = "" + seconds;
        }

     

        
    }
}