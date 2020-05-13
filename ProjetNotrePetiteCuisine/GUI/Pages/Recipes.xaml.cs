using ProjetNotrePetiteCuisine.Data;
using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using ProjetNotrePetiteCuisine.GUI.Windows;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetNotrePetiteCuisine.GUI.Pages
{
    /// <summary>
    /// Logique d'interaction pour Recipes.xaml
    /// </summary>
    public partial class Recipes : Page
    {
        Database database;
        Client client;

        public Recipes(Database database, Client client)
        {
            this.database = database;
            this.client = client;
            InitializeComponent();
            FillDatagrid();
        }

        private void FillDatagrid()
        {
            try
            {
                RecipesDataGrid.ItemsSource = this.database.GetValidRecipesOrderByName();
            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }
        private void RecipesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecipesDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new RecipeDisplay(database, client, (Recipe)RecipesDataGrid.SelectedItem));
            }
            else
            {
                App.ShowExceptionPopup(new CookingException("Please select a Recipe !"));
            }
        }

        
        //Display the recipe
        private void ShowRecipe(object sender, RoutedEventArgs e)
        {
            if (RecipesDataGrid.SelectedItem != null)
            {
                NavigationService.Navigate(new RecipeDisplay(database, client, (Recipe)RecipesDataGrid.SelectedItem));
            }
            else
            {
                App.ShowExceptionPopup(new CookingException("Please select a Recipe !"));
            }
        }
    }
}
