using Airport.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для ListOfTickets.xaml
    /// </summary>
    public partial class ListOfTickets : Page
    {
        public ListOfTickets()
        {
            InitializeComponent();
            lvListTickets.ItemsSource = Base.BE.Box_Offic.ToList();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new MainMenuPage());
        }

        private void tbDiscounts_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<ApplicationOfDiscounts> AOD = Base.BE.ApplicationOfDiscounts.Where(x => x.id_ticket == index).ToList();
            string str = "";
            foreach (ApplicationOfDiscounts aod in AOD)
            {
                str += "\n" + aod.Discounts.description + " - " + aod.Discounts.value + " %";
            }
            if(str.Length > 0)
            {
                tb.Text = "Применённые скидки: " + str;
            }
        }

        private void tbCost_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            double summDiscounts = 0; // Сумма всех скидок
            List<ApplicationOfDiscounts> AOD = Base.BE.ApplicationOfDiscounts.Where(x => x.id_ticket == index).ToList();
            foreach (ApplicationOfDiscounts aod in AOD)
            {
                summDiscounts += aod.Discounts.value;
            }
            Box_Offic box_Offic = Base.BE.Box_Offic.FirstOrDefault(x => x.id_ticket == index);
            Flights flights = Base.BE.Flights.FirstOrDefault(x => x.id_flight == box_Offic.id_flight);
            double cost = flights.cost - (flights.cost / 100 * summDiscounts);
            tb.Text = cost + " руб.";
        }

        private void tbDeparturePoint_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            Citys city = Base.BE.Citys.FirstOrDefault(x => x.id_city == index);
            tb.Text = city.city;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new AddTickets());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Box_Offic ticket = Base.BE.Box_Offic.FirstOrDefault(x => x.id_ticket == index);
            Base.BE.Box_Offic.Remove(ticket);         
            Base.BE.SaveChanges();
            Frameclass.MainFrame.Navigate(new ListOfTickets());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Box_Offic ticket = Base.BE.Box_Offic.FirstOrDefault(x => x.id_ticket == index);
            Frameclass.MainFrame.Navigate(new AddTickets(ticket));
        }
    }
}
