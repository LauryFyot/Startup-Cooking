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
    /// Logique d'interaction pour GestionClients.xaml
    /// </summary>
    public partial class GestionClients : Page
    {
        private Database database;
        public GestionClients(Database database)
        {
            this.database = database;
            InitializeComponent();
            FillDatagrid();
        }

        private void FillDatagrid()
        {
            try
            {
                ClientsDatagrid.ItemsSource = this.database.GetAllClients();
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePageAdmin(this.database));
        }


        //Display all recipes and quantity in the client's cart
        private void ActualCart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClientsDatagrid.SelectedItem != null) 
                {
                    Client client = (Client)ClientsDatagrid.SelectedItem;
                    string ActualCart = "";
                    foreach (KeyValuePair<Recipe, int> kvp in client.Cart)
                    {
                        ActualCart += kvp.Key.Name + " x" + kvp.Value.ToString() + "\n";
                    }
                    throw new CookingException(ActualCart);
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        //Display all orders already made by the client
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClientsDatagrid.SelectedItem != null)
                {
                    Client client = (Client)ClientsDatagrid.SelectedItem;
                    string AllOrders = "";
                    foreach (OrderType o in client.Orders)
                    {
                        Console.WriteLine(o);
                        AllOrders += o.OrderID.ToString() + ": " + o.Address + ", " + o.PostalCode + ", " + o.City + " à " + o.TheDate.ToString() + "\n";
                    }
                    throw new CookingException(AllOrders);
                }
                
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }

        //Delete the client
        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ClientsDatagrid.SelectedItem != null)
                {
                    this.database.DeleteClient((Client)ClientsDatagrid.SelectedItem);
                    this.FillDatagrid();
                }
            }
            catch (Exception ex)
            {
                App.ShowExceptionPopup(ex);
            }
        }
    }
}
