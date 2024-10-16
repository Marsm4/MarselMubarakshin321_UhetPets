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

namespace MarselMubarakshin321_UhetPets.Pages
{
    /// <summary>
    /// Логика взаимодействия для PetsPage.xaml
    /// </summary>
    public partial class PetsPage : Page
    {
        private string petName;
        public PetsPage(string name)
        {
            InitializeComponent();
            petName = name;
            LoadPets();
        }
        private void LoadPets()
        {
            try
            {
                var pets = DatabaseConnectionClass.DatabaseConnection.Pets
                    .Where(p => p.Names == petName).ToList();
                PetsListView.ItemsSource = pets;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки питомцев: " + ex.Message);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredPets = DatabaseConnectionClass.DatabaseConnection.Pets
                .Where(p => p.Names == petName && p.Opisanie.Contains(SearchTextBox.Text)).ToList();
            PetsListView.ItemsSource = filteredPets;
        }
        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  логика сортировки списка питомцев
        }

     

        private void AddPetBtn_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AddPetPage());
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Поиск питомца...")
            {
                SearchTextBox.Text = string.Empty;
                SearchTextBox.Foreground = System.Windows.Media.Brushes.Black; 
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Поиск питомца...";
                SearchTextBox.Foreground = System.Windows.Media.Brushes.Gray; 
            }
        }
    }
}