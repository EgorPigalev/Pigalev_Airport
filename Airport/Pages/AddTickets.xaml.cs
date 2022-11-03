using System;
using System.Collections.Generic;
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

namespace Airport.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddTickets.xaml
    /// </summary>
    public partial class AddTickets : Page
    {
        Box_Offic ticket;
        bool flagUpdate = false;
        public void uploadFields()  // метод для заполнения списков
        {
            cbDeparture_point.ItemsSource = Base.BE.Citys.ToList();
            cbDeparture_point.SelectedValuePath = "id_city";
            cbDeparture_point.DisplayMemberPath = "city";

            cbArrival_point.ItemsSource = Base.BE.Citys.ToList();
            cbArrival_point.SelectedValuePath = "id_city";
            cbArrival_point.DisplayMemberPath = "city";

            cbPassenger.ItemsSource = Base.BE.Passengers.ToList();
            cbPassenger.SelectedValuePath = "id_passenger";
            cbPassenger.DisplayMemberPath = "surname";

            cbEmployee.ItemsSource = Base.BE.Employees.ToList();
            cbEmployee.SelectedValuePath = "id_employee";
            cbEmployee.DisplayMemberPath = "surname";

            lbDiscount.ItemsSource = Base.BE.Discounts.ToList();
        }
        public AddTickets()
        {
            InitializeComponent();
            uploadFields();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new ListOfTickets());
        }
    }
    
}
