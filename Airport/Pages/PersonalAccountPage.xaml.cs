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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccountPage:Page
    {
        Employees User;
        public PersonalAccountPage(Employees User)
        {
            InitializeComponent();
            this.User = User;
            tbLogin.Text = User.login;
            tbFIO.Text = tbFIO.Text + User.surname + " " + User.name + " " + User.patronomic;
            tbGender.Text = tbGender.Text + User.Gender.gender;
            tbDateOfBirth.Text = tbDateOfBirth.Text + User.date_of_birth.ToString("dd MMMM yyyy");
            tbRole.Text = tbRole.Text + User.Roles.role;
            if(User.phone != "")
            {
                tbPhone.Text = User.phone;
            }
            else
            {
                tbPhone.Foreground = Brushes.Red;
                tbPhone.Text = "не задано";
            }

            if (User.Passport_deta.series != null)
            {
                tbSeria.Text = Convert.ToString(User.Passport_deta.series);
            }
            else
            {
                tbSeria.Foreground = Brushes.Red;
                tbSeria.Text = "не задано";
            }
            if (User.Passport_deta.nomer != null)
            {
                tbNomer.Text = Convert.ToString(User.Passport_deta.nomer);
            }
            else
            {
                tbNomer.Foreground = Brushes.Red;
                tbNomer.Text = "не задано";
            }
            if (User.Passport_deta.date_issue != null)
            {
                DateTime date = (DateTime)User.Passport_deta.date_issue;
                tbDateIssue.Text = date.ToString("dd.MM.yyyy");
            }
            else
            {
                tbDateIssue.Foreground = Brushes.Red;
                tbDateIssue.Text = "не задано";
            }
            if (User.Passport_deta.division_code != null)
            {
                tbDivisionCode.Text = User.Passport_deta.division_code;
            }
            else
            {
                tbDivisionCode.Foreground = Brushes.Red;
                tbDivisionCode.Text = "не задано";
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new MainMenuPage(User));
        }

        private void btnChangeMainData_Click(object sender, RoutedEventArgs e)
        {
            UpdMainData updMainData = new UpdMainData(User);
            updMainData.ShowDialog();
            Frameclass.MainFrame.Navigate(new PersonalAccountPage(User));
        }

        private void btnChangeLoginAndPassword_Click(object sender, RoutedEventArgs e)
        {
            UpdLoginAndPassword updLoginAndPassword = new UpdLoginAndPassword(User);
            updLoginAndPassword.ShowDialog();
            Frameclass.MainFrame.Navigate(new PersonalAccountPage(User));
        }

        private void btnChangePassportData_Click(object sender, RoutedEventArgs e)
        {
            UpdPassportData updPassportData = new UpdPassportData(User);
            updPassportData.ShowDialog();
            Frameclass.MainFrame.Navigate(new PersonalAccountPage(User));
        }

        private void btnChangeImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
