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
using System.Windows.Shapes;

namespace ProjetNotrePetiteCuisine.GUI.Windows
{
    /// <summary>
    /// Interaction logic for ErrorPopup.xaml
    /// </summary>
    public partial class ErrorPopup : Window
    {
        public ErrorPopup()
        {
            InitializeComponent();
        }

        public void SetMessage(string msg)
        {
            this.exception_message.Content = msg;
        }

        private void ClosePopup(object sender, RoutedEventArgs args)
        {
            this.Close();
        }
    }
}
