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
using MySql.Data.MySqlClient;
using System.Data;
using ProjetNotrePetiteCuisine.Data;
using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using System.Text.RegularExpressions;

namespace ProjetNotrePetiteCuisine.GUI.Windows
{
    /// <summary>
    /// Logique d'interaction pour Proposition.xaml
    /// </summary>
    public partial class Proposition : Window
    {
        private RecipeCreator recipeCreator;
        private Database database;

        public Proposition(RecipeCreator recipeCreator, Database database)
        {
            this.recipeCreator = recipeCreator;
            this.database = database;
            this.InitializeComponent();
            foreach (ComboBox c in this.StackPanelIngredients.Children) // Fill products in ComboBox
            {
                this.FillComboBox(c);
            }
            FillComboboxCategories();
            TemporaryFill();
        }

        private void TemporaryFill()
        {
            NomRecetteTextBox.Text = "Aubergines au four ail et parmesan";
            DescriptifRecetteTextBox.Text = "Aubergines au four avec de l'ail et parmesan : un bon plat d'été ensoleillé.";
            NbrEtapesTextBox.Text = "3";
            NbrPersonnesTextBox.Text = "4";
            DifficulteTextBox.Text = "2";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // For number TextBox
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        public void FillComboBox(ComboBox cmbx)
        {
            try
            {
                List<Product> products = this.database.GetAllProducts();
                cmbx.ItemsSource = products;
            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }

        // Events
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb.Width = 350;
            cb.Height = 30;
            TextBox tx = new TextBox();
            tx.Width = 60;
            tx.Height = 30;
            Label l = new Label();
            l.Width = 80;
            l.Height = 30;
            cb.BorderBrush = ComboboxIngerdient3.BorderBrush.Clone();
            tx.BorderBrush = TextBoxQte3.BorderBrush.Clone();
            l.Foreground = UniteLabel.Foreground;
            l.Opacity = UniteLabel.Opacity;
            l.FontFamily = UniteLabel.FontFamily;
            cb.Margin = ComboboxIngerdient3.Margin;
            tx.Margin = TextBoxQte3.Margin;
            StackPanelIngredients.Children.Add(cb);
            StackPanelQtes.Children.Add(tx);
            StackPanelUnitesLabel.Children.Add(l);
            FillComboBox(cb);
        }

        private void FillComboboxCategories()
        {
            List<string> choices = new List<string> { "Entrée", "Plat", "Dessert" };
            foreach (string s in choices)
            {
                CategorieCombobox.Items.Add(s);
            }
        }

        private void PropositionButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (String.IsNullOrWhiteSpace(this.NomRecetteTextBox.Text))
                {
                    throw new CookingException("Please fill the Recipe name !");
                }
                else if (String.IsNullOrWhiteSpace(this.DescriptifRecetteTextBox.Text))
                {
                    throw new CookingException("Please fill the Description !");
                }
                else if (String.IsNullOrWhiteSpace(this.NbrPersonnesTextBox.Text))
                {
                    throw new CookingException("Please fill the for number of people !");
                }
                else if (String.IsNullOrWhiteSpace(this.NbrEtapesTextBox.Text))
                {
                    throw new CookingException("Please fill the number of steps !");
                }
                else if (String.IsNullOrWhiteSpace(this.DifficulteTextBox.Text))
                {
                    throw new CookingException("Please fill the Difficulty level !");
                }
                else if (CategorieCombobox.SelectedItem==null)
                {
                    throw new CookingException("Please select a Category !");
                }
                else if (String.IsNullOrWhiteSpace(this.PrixClientTextBox.Text))
                {
                    throw new CookingException("Please fill the Price !");
                }

                Dictionary<Product, int> products = new Dictionary<Product, int>();
                for (int i = 0; i < this.StackPanelIngredients.Children.Count; i++) // Iterate all Product ComboBox
                {
                    ComboBox comboBox = (ComboBox)this.StackPanelIngredients.Children[i];
                    if (comboBox.SelectedItem != null) // Check if a product is selected in the ComboBox
                    {
                        string qty = ((TextBox)this.StackPanelQtes.Children[i]).Text;
                        if (String.IsNullOrWhiteSpace(qty)) // Check if the product quantity is filled
                        {
                            throw new CookingException("Please fill the Quantity for all Products selected !");
                        }
                        products.Add(((Product)comboBox.SelectedItem), int.Parse(qty)); // Add the product with his quantity
                    }
                }

                if (products.Count == 0) // Check If one or more Products are selected
                {
                    throw new CookingException("Please select one or more products !");
                }

                Recipe recipe = new Recipe(this.NomRecetteTextBox.Text, //
                    this.DescriptifRecetteTextBox.Text, //
                    this.CategorieCombobox.SelectedItem.ToString(), //
                    int.Parse(this.PrixClientTextBox.Text), // Safe because field is number only !
                    int.Parse(this.DifficulteTextBox.Text), // Safe because field is number only !
                    int.Parse(this.NbrPersonnesTextBox.Text), // Safe because field is number only !
                    int.Parse(this.NbrEtapesTextBox.Text), // Safe because field is number only !
                    this.recipeCreator);

                foreach (KeyValuePair<Product, int> entry in products) // Add all products in the Recipe
                {
                    recipe.Products.Add(entry.Key, entry.Value);
                }

                this.database.InsertRecipe(recipe); // Finally insert the Recipe with all Products REFERENCES (HAS_PRODUCT) !
                this.Close();
                throw new CookingException("Votre proposition va être traitée au plus vite !");
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < this.StackPanelIngredients.Children.Count; i++) // Iterate all Product ComboBox
            {
                Product product = (Product)((ComboBox)this.StackPanelIngredients.Children[i]).SelectedItem;
                Label unit = (Label)this.StackPanelUnitesLabel.Children[i];

                if (product != null)
                {
                    unit.Content = product.Unit; // Set/Update Unit Label
                }
            }
        }
    }
}
