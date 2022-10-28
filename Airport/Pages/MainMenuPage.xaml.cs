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
    /// Логика взаимодействия для MainMenuAdminPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static string LoginUser; // Логин пользователя который вошёл в систему
        public MainMenuPage()
        {
            InitializeComponent();
            Employees user = Base.BE.Employees.FirstOrDefault(x => x.login == LoginUser);
            tbRoleUser.Text = tbRoleUser.Text + " " + user.Roles.role;
            tbFIOUser.Text = user.surname + " " + user.name[0] + ". " + user.patronomic[0] + ".";
            if(user.Roles.role == "Пользователь")
            {
                btnSeeUsers.Visibility = Visibility.Collapsed;
                btnSeeTickets.Visibility = Visibility.Collapsed;
            }
            else
            {
                btnSeeUsers.Visibility = Visibility.Visible;
                btnSeeTickets.Visibility = Visibility.Visible;
            }
        }

        private void btnSeeUsers_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new SeeUsers());
        }

        private void btnExitMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new MainPage());
        }

        private void btnSeeTickets_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new ListOfTickets());
        }
    }
}
