using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace DeathClockApp.DataModel
{
    [ParseClassName("Users")]
    public class Users : ParseObject
    {
        [ParseFieldName("email")]
        public string Email
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("latitude")]
        public double Latitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("longtitude")]
        public double Longtitude
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }
    }
}
