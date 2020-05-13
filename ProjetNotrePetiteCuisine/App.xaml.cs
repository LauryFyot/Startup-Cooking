using ProjetNotrePetiteCuisine.Data;
using ProjetNotrePetiteCuisine.Data.Base;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using ProjetNotrePetiteCuisine.GUI.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetNotrePetiteCuisine
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // To speak in english numbers (4,5 => NO | 4.5 => YES ! )
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            Console.WriteLine("Start of the Application !");

            MainWindow main = new MainWindow();
            main.Show();

            //Console.WriteLine("End of the Application !");
        }

        public static void ShowExceptionPopup(Exception e)
        {
            ErrorPopup popup = new ErrorPopup();
            popup.Title = e.GetType().Name;
            popup.SetMessage(e.Message);
            popup.ShowDialog();
        }
    }
}
