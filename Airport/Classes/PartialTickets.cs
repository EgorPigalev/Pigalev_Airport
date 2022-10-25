using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Airport
{
    public partial class Box_Offic
    {
        public string NamePassenger
        {
            get
            {
                return Passengers.surname + " " + Passengers.name[0] + "." + Passengers.patronomic[0] + ".";
            }
        }

        public string NameEmployee
        {
            get
            {
                return Employees.surname + " " + Employees.name[0] + "." + Employees.patronomic[0] + ".";
            }
        }

        public SolidColorBrush TimeColor
        {
            get
            {
                TimeSpan timeMorning = TimeSpan.FromHours(7);
                TimeSpan timeEvening = TimeSpan.FromHours(11);
                if (Flights.departure_time > timeMorning && Flights.departure_time < timeEvening)
                {
                    return Brushes;
                }
                else
                {
                    return Brushes.Blue;
                }
            }
        }
    }
}
