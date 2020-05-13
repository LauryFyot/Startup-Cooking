using ProjetNotrePetiteCuisine.Data;
using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data.Exceptions;
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
    /// Interaction logic for UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Page
    {
        private Database database;

        public UserRegister(Database database)
        {
            this.database = database;
            InitializeComponent();
            TemporaryFill();
        }


        private void TemporaryFill()
        {
            UsernameTextBox.Text = "Marie94";
            PrenomTextBox.Text = "Marie";
            NomTextBox.Text = "DUPONT";
            MailTextBox.Text = "marie.dupont@free.fr";
            NumtelTextBox.Text = "0648759102";
        }

        // Events
        public void NavigateLogin(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new UserLogin(this.database));
        }
        public void SignUp(object sender, RoutedEventArgs args)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(this.UsernameTextBox.Text))
                {
                    throw new CookingException("Please fill the Username !");
                }
                else if (String.IsNullOrWhiteSpace(this.PrenomTextBox.Text))
                {
                    throw new CookingException("Please fill the First Name !");
                }
                else if (String.IsNullOrWhiteSpace(this.NomTextBox.Text))
                {
                    throw new CookingException("Please fill the Last Name !");
                }
                else if (String.IsNullOrWhiteSpace(this.MailTextBox.Text))
                {
                    throw new CookingException("Please fill the Email !");
                }
                else if (String.IsNullOrWhiteSpace(this.NumtelTextBox.Text))
                {
                    throw new CookingException("Please fill the Phone Number !");
                }
                else if (String.IsNullOrWhiteSpace(this.ChoosePasswordTextBox.Password))
                {
                    throw new CookingException("Please fill the Password !");
                }
                else if (String.IsNullOrWhiteSpace(this.ConfirmPasswordTextBox.Password))
                {
                    throw new CookingException("Please confirm the Password !");
                }
                else if (!this.ChoosePasswordTextBox.Password.Equals(this.ConfirmPasswordTextBox.Password))
                {
                    throw new CookingException("Passwords are not equals !");
                }

                Client client = null;

                if (this.CdRCheckbox.IsChecked == true) // If it's a RecipeCreator
                {
                    client = new RecipeCreator(this.UsernameTextBox.Text, //
                        this.ChoosePasswordTextBox.Password, //
                        this.PrenomTextBox.Text, //
                        this.NomTextBox.Text, //
                        this.NumtelTextBox.Text, //
                        this.MailTextBox.Text);
                    this.database.InsertClientAsRecipeCreator((RecipeCreator) client);
                }
                else // If it's only a Client
                {
                    client = new Client(this.UsernameTextBox.Text, //
                        this.ChoosePasswordTextBox.Password, //
                        this.PrenomTextBox.Text, //
                        this.NomTextBox.Text, //
                        this.NumtelTextBox.Text, //
                        this.MailTextBox.Text);
                    this.database.InsertClient(client);
                }


                // Now the Client is registred and logged => Go where you want with the Object and the Database...
                NavigationService.Navigate(new BasePage(this.database, client));

                //NavigationService.Navigate(new UserLogin(this.database));
                //BaseWindow wnd = new BaseWindow(this.database, client);
                //wnd.Show();
            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }

    }
}
