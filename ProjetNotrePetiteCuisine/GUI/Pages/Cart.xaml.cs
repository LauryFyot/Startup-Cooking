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

namespace ProjetNotrePetiteCuisine.GUI.Pages
{
    /// <summary>
    /// Logique d'interaction pour Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        private Database database;
        private Client client;
        public Cart(Database database, Client client)
        {
            this.database = database;
            this.client = client;
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            RecipeCartDatagrid.ItemsSource = this.client.Cart;

            TotalPrice.Text = this.client.TotalCart().ToString();

            if (RecipeCartDatagrid == null || RecipeCartDatagrid.Items.Count == 0)
            {
                OrderButton.IsEnabled = false;
            }

            //If client is RecipeCreator display the price minus cookbalance
            if (this.client.GetType() == typeof(RecipeCreator))
            {
                RecipeCreator recipeCreator = (RecipeCreator)this.client;
                int price = recipeCreator.TotalCartAfterDeduction();
                if (price >= 0)
                {
                    TotalPriceAfterDeduction.Text = price.ToString();
                }
                else
                {
                    TotalPriceAfterDeduction.Text = "0";
                }
            }
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Increasing by 1 the selected item in the client's cart
                if (RecipeCartDatagrid.SelectedItem != null)
                {
                    KeyValuePair<Recipe, int> kvp = (KeyValuePair<Recipe, int>)RecipeCartDatagrid.SelectedItem;
                    KeyValuePair<Recipe, int> kvp2 = new KeyValuePair<Recipe, int>(kvp.Key, kvp.Value + 1);
                    this.database.UpdateRecipeInCartOf(client, kvp2);
                    this.client.Cart[kvp2.Key] = kvp2.Value;
                    RecipeCartDatagrid.Items.Refresh();
                    Fill();
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Delete the selected recipe in the client's cart
                if (RecipeCartDatagrid.SelectedItem != null)
                {
                    KeyValuePair<Recipe, int> kvp = (KeyValuePair<Recipe, int>)RecipeCartDatagrid.SelectedItem;
                    this.database.DeleteRecipeInCartOf(client, kvp.Key);
                    this.client.Cart.Remove(kvp.Key);
                    RecipeCartDatagrid.Items.Refresh();
                    Fill();
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Decreasing by 1 the selected recipe in the client's cart
                if (RecipeCartDatagrid.SelectedItem != null)
                {
                    KeyValuePair<Recipe, int> kvp = (KeyValuePair<Recipe, int>)RecipeCartDatagrid.SelectedItem;
                    KeyValuePair<Recipe, int> kvp2 = new KeyValuePair<Recipe, int>(kvp.Key, kvp.Value - 1);
                    if (kvp.Value > 0)
                    {
                        this.database.UpdateRecipeInCartOf(client, kvp2);
                        this.client.Cart[kvp2.Key] = kvp2.Value;
                        RecipeCartDatagrid.Items.Refresh();
                        Fill();
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Order(this.database, this.client));
        }
    }
}
