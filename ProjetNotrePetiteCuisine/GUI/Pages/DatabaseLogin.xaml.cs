using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using ProjetNotrePetiteCuisine.GUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class DatabaseLogin : Page
    {
        public DatabaseLogin()
        {
            InitializeComponent();
            TemporaryFill();
        }

        private void TemporaryFill()
        {
            UsernameTextBox.Text = "root";
            DomainTextBox.Text = "localhost";
            PortTextBox.Text = "3306";
        }

        //Allows only writing numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // For number TextBox
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        // Events
        public void LoginClient(object sender, RoutedEventArgs args)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(this.UsernameTextBox.Text))
                {
                    throw new CookingException("Please fill Username !");
                }
                else if (String.IsNullOrWhiteSpace(this.PasswordTextBox.Password))
                {
                    throw new CookingException("Please fill Password !");
                }
                else if (String.IsNullOrWhiteSpace(this.DatabaseTextBox.Text))
                {
                    throw new CookingException("Please fill Database name !");
                }
                else if (String.IsNullOrWhiteSpace(this.DomainTextBox.Text))
                {
                    throw new CookingException("Please fill Domain !");
                }
                else if (String.IsNullOrWhiteSpace(this.PortTextBox.Text))
                {
                    throw new CookingException("Please fill Port !");
                }

                Database database = new Database(this.DomainTextBox.Text, //
                    int.Parse(this.PortTextBox.Text), //
                    this.DatabaseTextBox.Text, //
                    this.UsernameTextBox.Text, //
                    this.PasswordTextBox.Password);

                if (!database.TestConnection())
                {
                    throw new CookingException("Failed to connect !");
                }

                bool populateDatabase = true;
                if (database.TablesExist() && database.TriggersExist() && database.EventsExist()) // If every Sql objects exists
                {
                    string sMessageBoxText = "Do you want to Clean then Populate Database ?";
                    string sCaption = "Database Initialization";

                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Question;
                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                    populateDatabase = rsltMessageBox == MessageBoxResult.Yes; // Yes Clean and Populate Database ?
                }

                // Here we Populate the Database if needed
                DatabasePopulateProgressBar p = new DatabasePopulateProgressBar(database, populateDatabase);
                p.Start();
                p.ShowDialog();

                //XmlPrinter.PrintLastWeekOrders(database);

                NavigationService.Navigate(new UserLogin(database));
            }
            catch (Exception e)
            {
                App.ShowExceptionPopup(e);
            }
        }
    }
}
