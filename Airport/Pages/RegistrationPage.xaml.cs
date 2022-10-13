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
using System.Text.RegularExpressions;

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            cbGender.ItemsSource = Base.BE.Gender.ToList();
            cbGender.SelectedValuePath = "id_gender";
            cbGender.DisplayMemberPath = "gender";
            cbGender.SelectedIndex = 0;
        }

        private void TBNextRegistration_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Frameclass.MainFrame.Navigate(new AuthorizationPage());
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if(tbSurname.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле фамилия должно быть заполнено!");
                return;
            }
            else if (tbName.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле имя должно быть заполнено!");
                return;
            }
            else if (tbPatronomic.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле Отчество должно быть заполнено!");
                return;
            }
            else if (cbGender.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле пол должно быть заполнено!");
                return;
            }
            else if (dpBrithday.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле дата рождения должно быть заполнено!");
                return;
            }
            else if (tbLogin.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле логин должно быть заполнено!");
                return;
            }
            else if (pbPassword.ToString().Replace(" ", "") == "")
            {
                MessageBox.Show("Поле пароль должно быть заполнено!");
                return;
            }
            else if (pbPassword.ToString() != pbPasswordRepeated.ToString())
            {
                MessageBox.Show("Пароль не подтверждён!");
                return;
            }
            else if (pbPassword.ToString() != pbPasswordRepeated.ToString())
            {
                MessageBox.Show("Пароль не подтверждён!");
                return;
            }
            Employees employee = new Employees()
            {
                surname = tbSurname.Text,
                name = tbName.Text,
                patronomic = tbPatronomic.Text,
                id_gender = cbGender.SelectedIndex + 1,
                date_of_birth = Convert.ToDateTime(dpBrithday.SelectedDate),
                phone = tbPhone.Text,
                login = tbLogin.Text,
                password = Convert.ToString(pbPassword.Password.GetHashCode()),
                id_role = 2
            };
            Base.BE.Employees.Add(employee);
            Base.BE.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались");
            Frameclass.MainFrame.Navigate(new AuthorizationPage());
        }
    }
}
