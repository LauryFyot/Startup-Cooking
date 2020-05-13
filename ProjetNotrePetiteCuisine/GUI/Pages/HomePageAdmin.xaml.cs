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
    /// Logique d'interaction pour HomePageG.xaml
    /// </summary>
    public partial class HomePageAdmin : Page
    {
        private Database database;
        public HomePageAdmin(Database database)
        {
            this.database = database;
            InitializeComponent();
        }

        private void GestionRecetteButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GestionRecette(this.database));
        }

        private void GestionProduitsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GestionProduits(this.database));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePageAdmin(this.database));
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DashboardPage(this.database));
        }

        private void WeeklyOderList_Click(object sender, RoutedEventArgs e)
        {
            XmlPrinter.PrintLastWeekOrders(this.database); //Edit the list of this week's orders in fromat xml
        }

        private void GestionClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GestionClients(this.database));
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertAdmin(this.database));
        }

        private void AllRC_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GestionCdR(this.database));
        }
    }
}
