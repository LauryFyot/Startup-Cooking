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
    /// Logique d'interaction pour InsertAdmin.xaml
    /// </summary>
    public partial class InsertAdmin : Page
    {
        private Database database;
        public InsertAdmin(Database database)
        {
            this.database = database;
            InitializeComponent();
            TemporaryFill();
        }

        //Prefilling
        private void TemporaryFill()
        {
            UsernameTextBox.Text = "Loic";
            PrenomTextBox.Text = "Loic";
            NomTextBox.Text = "VERNON";
            MailTextBox.Text = "loicvernon@gmail.fr";
            NumtelTextBox.Text = "0647895134";
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePageAdmin(this.database));
        }


        private void AddAdmin_Click(object sender, RoutedEventArgs e)
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

                Admin admin = new Admin(this.UsernameTextBox.Text, //
                    this.ChoosePasswordTextBox.Password, //
                    this.PrenomTextBox.Text, //
                    this.NomTextBox.Text, //
                    this.NumtelTextBox.Text, //
                    this.MailTextBox.Text);
                
                //Adding the admin both as a client and as an admin
                this.database.InsertClientAsAdmin(admin);
                NavigationService.Navigate(new HomePageAdmin(this.database));
                throw new Exception("The new admin has been registered !");
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
