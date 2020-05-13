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
    /// Logique d'interaction pour RecipeDisplay.xaml
    /// </summary>
    public partial class RecipeDisplay : Page
    {
        Database database;
        Client client;
        Recipe recipe;
        public RecipeDisplay(Database database, Client client, Recipe recipe)
        {
            this.database = database;
            this.client = client;
            this.recipe = recipe;
            InitializeComponent();
            Fill();
            FillComboBox();
        }


        private void Fill()
        {
            NomTextBlock.Text = recipe.Name;
            CategoryTextBlock.Text = recipe.Type;
            PrixTextBlock.Text = recipe.Price.ToString();
            PseudoTextBlock.Text = recipe.RecipeCreatorUsername;
            DescriptifTextBlock.Text = recipe.Description;
            NbCommandesTextBlock.Text = recipe.NbSolded.ToString();
        }

        private void FillComboBox()
        {
            for (int i = 1; i < 20; i++)
            {
                QteComboBox.Items.Add(i.ToString());
            }
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Recipes(database, client));
        }


        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (QteComboBox.SelectedItem == null)
                {
                    throw new CookingException("Veuillez choisir une quantité !");
                }
                //Insert the recipe in the customer's cart with qty
                KeyValuePair<Recipe, int> kvp = new KeyValuePair<Recipe, int>(recipe, Int32.Parse(QteComboBox.SelectedItem.ToString()));
                database.InsertRecipeInCartOf(this.client, kvp);
                this.client.Cart[kvp.Key]= kvp.Value;

                NavigationService.Navigate(new Recipes(database, client));
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
