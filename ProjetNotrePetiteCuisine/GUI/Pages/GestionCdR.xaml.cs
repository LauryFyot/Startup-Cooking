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
    /// Logique d'interaction pour GestionCdR.xaml
    /// </summary>
    public partial class GestionCdR : Page
    {
        private Database database;
        public GestionCdR(Database database)
        {
            this.database = database;
            InitializeComponent();
            FillDatagrid();
        }

        private void FillDatagrid()
        {
            try
            {
                RcsDatagrid.ItemsSource = this.database.GetAllRC();
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


        private void DeleteRC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RcsDatagrid.SelectedItem != null)
                {
                    this.database.DeleteClient((Client)RcsDatagrid.SelectedItem);
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
