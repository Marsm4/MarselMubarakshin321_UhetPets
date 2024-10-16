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
using MarselMubarakshin321_UhetPets;
using MarselMubarakshin321_UhetPets.Models;
using MarselMubarakshin321_UhetPets.Pages;


namespace MarselMubarakshin321_UhetPets.Pages
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
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенные данные
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;

            // Проверяем пользователя в базе данных
            var user = DatabaseConnectionClass.DatabaseConnection.Users
                .FirstOrDefault(u => u.Username == username && u.Parol == password);

            if (user != null)
            {
                try
                {
                    if (user.Rolle == "Андрей пирокинезис")
                    {
                        NavigationService.Navigate(new PetsPage("Ра"));
                    }
                    else if (user.Rolle == "Деля")
                    {
                        NavigationService.Navigate(new PetsPage("Нуби"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка навигации: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void LoginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "Введите логин")
            {
                LoginTextBox.Text = string.Empty;
                LoginTextBox.Foreground = System.Windows.Media.Brushes.Black; 
            }
        }

        private void LoginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                LoginTextBox.Text = "Введите логин";
                LoginTextBox.Foreground = System.Windows.Media.Brushes.Gray; // Меняем цвет текста на серый
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == string.Empty)
            {
                PasswordBox.Clear();
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                
            }
        }
    }
}