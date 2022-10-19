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
            Frameclass.MainFrame.Navigate(new MainMenuAdminPage());
        }
    }
}
