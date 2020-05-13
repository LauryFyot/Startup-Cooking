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
    /// Logique d'interaction pour DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private Database database;
        public DashboardPage(Database database)
        {
            this.database = database;
            InitializeComponent();
            Fill();
        }
        
        private void Fill()
        {
            try
            {
                Dashboard dashboard = this.database.GetDashboard();

                ////Top Week
                CdrOfTheWeekName.Text = Convert.ToString(dashboard.BestRecipeCreatorOfWeek.FirstName) + "  " + Convert.ToString(dashboard.BestRecipeCreatorOfWeek.LastName);
                CdrOfTheWeekId.Text = Convert.ToString(dashboard.BestRecipeCreatorOfWeek.ClientID);

                Top5OfTheWeek.ItemsSource = dashboard.GetRecipesOfTheWeek();

                ////All Time Best CdR
                AllTimeCdrName.Text = Convert.ToString(dashboard.BestRecipeCreator.FirstName) + "  " + Convert.ToString(dashboard.BestRecipeCreator.LastName);
                AllTimeCdrId.Text = Convert.ToString(dashboard.BestRecipeCreator.ClientID);
                
                AllTimeCdrTop5.ItemsSource = dashboard.GetRecipesOfBestRC();
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
