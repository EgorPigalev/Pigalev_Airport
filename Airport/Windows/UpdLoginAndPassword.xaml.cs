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
using System.Windows.Shapes;

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для UpdLoginAndPassword.xaml
    /// </summary>
    public partial class UpdLoginAndPassword : Window
    {
        public UpdLoginAndPassword(Employees User)
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void imVisibleOldPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePasswordOld();
        }

        private void HidePasswordOld()
        {
            imVisibleOldPassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible.png", UriKind.Relative));
            tbOldPasswordVisible.Visibility = Visibility.Collapsed;
            pbOldPassword.Visibility = Visibility.Visible;
            pbOldPassword.Focus();
        }


        private void ShowPasswordOld()
        {
            imVisibleOldPassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible.png", UriKind.Relative));
            tbOldPasswordVisible.Visibility = Visibility.Visible;
            pbOldPassword.Visibility = Visibility.Collapsed;
            tbOldPasswordVisible.Text = pbOldPassword.Password;
        }
        private void imVisibleOldPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordOld();
        }

        private void imVisibleNewPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePasswordNew();
        }

        private void HidePasswordNew()
        {
            imVisibleNewPassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible.png", UriKind.Relative));
            tbNewPasswordVisible.Visibility = Visibility.Collapsed;
            pbNewPassword.Visibility = Visibility.Visible;
            pbNewPassword.Focus();
        }


        private void ShowPasswordNew()
        {
            imVisibleNewPassword.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible.png", UriKind.Relative));
            tbNewPasswordVisible.Visibility = Visibility.Visible;
            pbNewPassword.Visibility = Visibility.Collapsed;
            tbNewPasswordVisible.Text = pbNewPassword.Password;
        }

        private void imVisibleNewPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordNew();
        }

        private void imVisibleNewPasswordRepeated_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePasswordNewRepeated();
        }
        private void HidePasswordNewRepeated()
        {
            imVisibleNewPasswordRepeated.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_visible.png", UriKind.Relative));
            tbNewPasswordRepeatedVisible.Visibility = Visibility.Collapsed;
            pbNewPasswordRepeated.Visibility = Visibility.Visible;
            pbNewPasswordRepeated.Focus();
        }


        private void ShowPasswordNewRepeated()
        {
            imVisibleNewPasswordRepeated.Source = new BitmapImage(new Uri("..\\Resources\\icon_password_not_visible.png", UriKind.Relative));
            tbNewPasswordRepeatedVisible.Visibility = Visibility.Visible;
            pbNewPasswordRepeated.Visibility = Visibility.Collapsed;
            tbNewPasswordRepeatedVisible.Text = pbNewPasswordRepeated.Password;
        }
        private void imVisibleNewPasswordRepeated_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordNewRepeated();
        }
    }
}
