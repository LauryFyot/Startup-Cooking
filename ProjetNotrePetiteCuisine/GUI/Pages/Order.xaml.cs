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
using System.Text.RegularExpressions;

namespace ProjetNotrePetiteCuisine.GUI.Pages
{
    /// <summary>
    /// Logique d'interaction pour Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        private Database database;
        private Client client;

        public Order(Database database, Client client)
        {
            this.database = database;
            this.client = client;
            InitializeComponent();
            TemporaryFill();
            Fill();
        }

        //Prefilling
        private void TemporaryFill()
        {
            AddressTextBox.Text = "26 rue de la libération";
            PostalCodeTextBox.Text = "75000";
            CityTextBox.Text = "Paris";
        }

        private void Fill()
        {
            RecipeCartDatagrid.ItemsSource = this.client.Cart;
            TotalPrice.Text = this.client.TotalCart().ToString();

            //If client is RecipeCreator display the price minus cookbalance
            if (this.client.GetType() == typeof(RecipeCreator))
            {
                RecipeCreator recipeCreator = (RecipeCreator)this.client;
                int price = recipeCreator.TotalCartAfterDeduction();
                if (price>=0)
                {
                    TotalPriceAfterDeduction.Text = price.ToString();
                }
                else
                {
                    TotalPriceAfterDeduction.Text = "0";
                }
            }
        }



        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // For number TextBox
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }



        private void Order_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(this.AddressTextBox.Text))
                {
                    throw new CookingException("Please fill the address !");
                }
                else if (String.IsNullOrWhiteSpace(this.CityTextBox.Text))
                {
                    throw new CookingException("Please fill the city !");
                }
                else if (String.IsNullOrWhiteSpace(this.PostalCodeTextBox.Text))
                {
                    throw new CookingException("Please fill the postal code !");
                }

                //Order
                OrderType neworder = new OrderType(AddressTextBox.Text, CityTextBox.Text, PostalCodeTextBox.Text, this.client);

                foreach (KeyValuePair<Recipe, int> kvp in client.Cart)
                {
                    neworder.Recipes.Add(kvp.Key,kvp.Value);
                }

                //Insert order in database and client.Orders
                this.database.InsertOrder(client, neworder);
                this.client.Orders.Add(neworder);

                //Clear cart after order
                this.client.Cart.Clear();

                NavigationService.Navigate(new HomePage());
                throw new CookingException("Your order has been placed!");
                
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }

        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cart(database, client));
        }
    }
}
