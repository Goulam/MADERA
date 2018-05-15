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
using Madera.ClassLibrary.BLL;
using Madera.ClassLibrary.Entity;
using System.Collections.ObjectModel;

namespace Madera
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        //
        // Variable de "session"  
        //

        CommerciauxEntity commercial;

        public Dashboard()
        {
            InitializeComponent();
        }

        public void setCommercial(CommerciauxEntity entering)
        {
            this.commercial = entering;
        }

        public CommerciauxEntity getCommercial()
        {
            return this.commercial;
        }

        public void goToAccueil(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/Accueil.xaml", UriKind.Relative));
        }

        public void goToSearchClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/SearchClient.xaml", UriKind.Relative));
        }

        public void goToCreateDevis(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/CreateDevis.xaml", UriKind.Relative));
        }

        public void goToCreateClient(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/EnregistrerClient.xaml", UriKind.Relative));
        }
    }
}
