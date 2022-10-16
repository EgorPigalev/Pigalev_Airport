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
    public partial class MainMenuAdminPage : Page
    {
        public static string LoginUser; // Логин пользователя который вошёл в систему
        public MainMenuAdminPage()
        {
            InitializeComponent();
            tbRoleUser.Text = tbRoleUser.Text + " Администратор";
            Employees user = Base.BE.Employees.FirstOrDefault(x => x.login == LoginUser);
            tbFIOUser.Text = user.surname + " " + user.name[0] + ". " + user.patronomic[0] + ".";
        }

        private void btnSeeUsers_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new SeeUsers());
        }

        private void btnExitMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new MainPage());
        }
    }
}
