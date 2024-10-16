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
            var user = DatabaseConnectionClass.DatabaseConnection.Users
                .FirstOrDefault(u => u.Username == LoginTextBox.Text && u.Parol == PasswordBox.Password);

            if (user != null)
            {
                if (user.Rolle == "Андрей пирокинезис")
                    NavigationService.Navigate(new PetsPage("Ра"));
                else if (user.Rolle == "Деля")
                    NavigationService.Navigate(new PetsPage("Нуби"));
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}