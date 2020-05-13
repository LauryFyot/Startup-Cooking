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
using ProjetNotrePetiteCuisine.GUI.Windows;
using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data;
using System.Net;
using ProjetNotrePetiteCuisine.Data.Exceptions;

namespace ProjetNotrePetiteCuisine.GUI.Pages
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        private Database database;
        private Client client;

        public Profil(Database database, Client client)
        {
            this.client = client;
            this.database = database;
            this.InitializeComponent();
            this.FillInformations();
            this.FillComboBoxRecettes();
        }

        private void FillInformations()
        {
            UsernameTextBox.Text = this.client.Username;
            PrenomTextBox.Text = this.client.FirstName;
            NomTextBox.Text = this.client.LastName;
            NumtelTextBox.Text = this.client.PhoneNumber;
            MailTextBox.Text = this.client.Email;

            UsernameTextBox.IsEnabled = false;
            PrenomTextBox.IsEnabled = false;
            NomTextBox.IsEnabled = false;
            NumtelTextBox.IsEnabled = false;
            MailTextBox.IsEnabled = false;

            if (this.client.GetType() == typeof(Admin))
            {
                DevenirCdR.IsEnabled = false; //Cannot click if he is an admin
                ProposerUneRecetteButton.IsEnabled = false;
            }

            if (this.client.GetType() == typeof(RecipeCreator))
            {
                SoldeCookLabel.Text = ((RecipeCreator)this.client).CookBalance.ToString();
                DevenirCdR.IsEnabled = false; //If already a RC cannot click
                ProposerUneRecetteButton.IsEnabled = true;
            }
            else
            {
                ProposerUneRecetteButton.IsEnabled = false; //If he is not a RC cannot suggest a recipe
            }
        }

        public void FillComboBoxRecettes()
        {
            try
            {
                List<Recipe> recipesOfCurrentRecipeCreator = this.database.GetRecipeOfRecipeCreator(this.client);
                YourRecipeDatagrid.ItemsSource = recipesOfCurrentRecipeCreator;
            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }



        private void ProposerUneRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.client.GetType() != typeof(RecipeCreator))
            {
                App.ShowExceptionPopup(new CookingException("You must be a RecipeCreator to add recipe !"));
            } else
            {
                Proposition wnd = new Proposition((RecipeCreator)this.client, this.database);
                wnd.ShowDialog();

                this.FillComboBoxRecettes(); // Refresh ComboBoxRecettes
            }
        }


        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //The client is now a recipe creator on the entire app
                MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                if (mw != null)
                {
                    BasePage basepage = (BasePage)mw.DatabaseLoginFrame.Content;
                    basepage.BecomeRecipeCreator();
                }
                
                //The client is now a recipe creator on the page
                this.client = new RecipeCreator(this.client);

                this.FillInformations();
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
