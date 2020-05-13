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
    /// Logique d'interaction pour GestionRecette.xaml
    /// </summary>
    public partial class GestionRecette : Page
    {
        private Database database;
        public GestionRecette(Database database)
        {
            this.database = database;
            InitializeComponent();
            FillDataGrid();
        }

        //Fill the datagrid with all the recipes
        private void FillDataGrid()
        {
            try
            {
                List<Recipe> AllValidRecipes = this.database.GetValidRecipesOrderByName(); //Valid
                AllValidRecipes.AddRange(this.database.GetNotValidRecipesOrderByName()); //Not valid yet
                RecipesDatagrid.ItemsSource = AllValidRecipes;
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }



        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePageAdmin(this.database));
        }

        //Display all the products and quantities required for the selected recipe
        private void ShowProductList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecipesDatagrid.SelectedItem != null)
                {
                    Recipe RecipeSelected = (Recipe)RecipesDatagrid.SelectedItem;
                    string AllProducts = "";
                    foreach (KeyValuePair<Product, int> k in RecipeSelected.Products)
                    {
                        AllProducts += k.Key.ToString() + ": " + k.Value.ToString() + " " + k.Key.Unit.ToString() + "\n";
                    }
                    throw new CookingException(AllProducts);
                }

            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        //Delete the selected recipe
        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecipesDatagrid.SelectedItem != null)
                {
                    this.database.DeleteRecipe((Recipe)RecipesDatagrid.SelectedItem);
                    this.FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }


        //Validate the selected recipe. Now the recipe is suggested to the customers!
        private void ValidateRecipe_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RecipesDatagrid.SelectedItem != null)
                {
                    Recipe RecipeSelected = (Recipe)RecipesDatagrid.SelectedItem;
                    RecipeSelected.IsValidated = true; //Validate
                    this.database.UpdateRecipe(RecipeSelected);
                    this.FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
