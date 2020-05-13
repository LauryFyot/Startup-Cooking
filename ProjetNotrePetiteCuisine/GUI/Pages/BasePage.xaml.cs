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
    /// Logique d'interaction pour BasePage.xaml
    /// </summary>
    public partial class BasePage : Page
    {
        private Database database;
        private Client client;
        public BasePage(Database database, Client client)
        {
            this.database = database;
            this.client = client;
            InitializeComponent();

            //Restrict the access to the AdminButton to customers and RC
            if (this.client.GetType() != typeof(Admin))
            {
                this.admin_center.Visibility = Visibility.Hidden;
            }
            Main.Content = new HomePage();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage();
        }

        private void CommanderButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Recipes(this.database, client);
        }

        private void MonProfil_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profil(database, client);
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Cart(database, client);
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (this.client.GetType() == typeof(Admin)) //Only if he is an admin !
                {
                    Main.Content = new HomePageAdmin(this.database);
                } else
                {
                    MessageBox.Show("You must to be an Admin !");
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserLogin(this.database));
        }

        public void BecomeRecipeCreator()
        {
            try
            {
                this.client = new RecipeCreator(this.client); // Now the Client is a RecipeCreator !
                this.database.InsertOnlyRecipeCreator((RecipeCreator)this.client); // Insert him as a RecipeCreator in the Database
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
