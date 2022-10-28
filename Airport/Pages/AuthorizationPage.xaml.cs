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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {
            int p = pbPassword.Password.GetHashCode();
            Employees employees = Base.BE.Employees.FirstOrDefault(x => x.login == tboxLogin.Text && x.password == p);
            if(employees == null)
            {
                MessageBox.Show("Пользователь с таким логиным и паролем не найден!");
            }
            else
            {
                switch(employees.Roles.role)
                {
                    case "Администратор":
                        MainMenuPage.LoginUser = employees.login;
                        Frameclass.MainFrame.Navigate(new MainMenuPage());
                        break;
                    case "Пользователь":
                        MainMenuPage.LoginUser = employees.login;
                        Frameclass.MainFrame.Navigate(new MainMenuPage());
                        break;  
                    default:
                        MessageBox.Show("");
                        break;
                }
            }
        }

        private void TBNextRegistration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new RegistrationPage());
        }
    }
}
