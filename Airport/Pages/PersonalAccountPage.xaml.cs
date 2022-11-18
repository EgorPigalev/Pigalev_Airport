﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Brushes = System.Windows.Media.Brushes;

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccountPage:Page
    {
        Employees User;
        void showImage(byte[] Barray, ImageBrush img)
        {
            BitmapImage BI = new BitmapImage();
            using (MemoryStream m = new MemoryStream(Barray))
            {
                BI.BeginInit();
                BI.StreamSource = m;
                BI.CacheOption = BitmapCacheOption.OnLoad;
                BI.EndInit(); 
            }
            img.ImageSource = BI;
        }
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
            List<EmployeesPhoto> employeesPhotos = Base.BE.EmployeesPhoto.Where(x => x.id_employee == User.id_employee).ToList();
            if (employeesPhotos != null)
            {
                byte[] Bar = employeesPhotos.FirstOrDefault(x => x.actual == true).photo_binary;
                showImage(Bar, myImage);
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

        private void btnChangeImage_Click(object sender, RoutedEventArgs e) // Изменение аватарки
        {
            try
            {
                EmployeesPhoto employeesPhoto = new EmployeesPhoto();
                employeesPhoto.id_employee = User.id_employee;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();            
                string path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                employeesPhoto.photo_binary = Barray;
                employeesPhoto.actual = true;
                List<EmployeesPhoto> employeesPhotos = Base.BE.EmployeesPhoto.Where(x => x.id_employee == User.id_employee).ToList();
                foreach (EmployeesPhoto photo in employeesPhotos)
                {
                    photo.actual = false;
                }
                Base.BE.EmployeesPhoto.Add(employeesPhoto);
                Base.BE.SaveChanges();
                MessageBox.Show("Фото добавлено");
                Frameclass.MainFrame.Navigate(new PersonalAccountPage(User));
            }
            catch
            {
                MessageBox.Show("При добавлении нового фото возникла ошибка!");
            }
        }

        private void btnChangeImages_Click(object sender, RoutedEventArgs e) // Добавление фото в базу
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Multiselect = true;
                if (OFD.ShowDialog() == true)
                {
                    foreach (string file in OFD.FileNames)
                    {
                        EmployeesPhoto employeesPhoto = new EmployeesPhoto();
                        employeesPhoto.id_employee = User.id_employee;
                        string path = file;
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);
                        ImageConverter IC = new ImageConverter();
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                        employeesPhoto.photo_binary = Barray;
                        employeesPhoto.actual = false;
                        Base.BE.EmployeesPhoto.Add(employeesPhoto);
                    }
                    Base.BE.SaveChanges();
                    MessageBox.Show("Фото добавлены");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении нового фото возникла ошибка!");
            }
        }
    }
}
