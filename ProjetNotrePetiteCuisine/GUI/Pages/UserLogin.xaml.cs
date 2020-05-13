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
    /// Interaction logic for DatabaseLogin.xaml
    /// </summary>
    public partial class UserLogin : Page
    {
        private Database database;

        public UserLogin(Database database)
        {
            this.database = database;
            InitializeComponent();
        }

        // Events
        public void NavigateRegister(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new UserRegister(this.database));
        }

        public void SignIn(object sender, RoutedEventArgs args)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(this.UsernameTextBox.Text))
                {
                    throw new CookingException("Please fill the Username !");
                }
                else if (String.IsNullOrWhiteSpace(this.PasswordTextBox.Password))
                {
                    throw new CookingException("Please fill the Password !");
                }

                Client client = this.database.Login(this.UsernameTextBox.Text, this.PasswordTextBox.Password);

                // Now the Client is logged => Go where you want with the Object and the Database...
                NavigationService.Navigate(new BasePage(this.database, client));

            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }
    }
}
