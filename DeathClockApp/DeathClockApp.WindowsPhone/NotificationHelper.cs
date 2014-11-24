using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DeathClockApp
{
    public class NotificationHelper
    {
        public NotificationHelper()
        {

        }

        public void ShowMessageBox(string message, string title)
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
