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
    /// Logique d'interaction pour GestionProduits.xaml
    /// </summary>
    public partial class GestionProduits : Page
    {
        private Database database;
        public GestionProduits(Database database)
        {
            this.database = database;
            InitializeComponent();
            FillDatagrid();
        }

        //Fill the datagrid with all the products
        private void FillDatagrid()
        {
            try
            {
                ProductsDatagrid.ItemsSource = this.database.GetAllProducts();
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

    }
}
