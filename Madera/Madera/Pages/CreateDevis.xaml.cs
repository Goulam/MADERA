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
using Madera.ClassLibrary.BLL;
using Madera.ClassLibrary.Entity;
using System.Collections.ObjectModel;


namespace Madera.Pages
{
    /// <summary>
    /// Logique d'interaction pour CreateDevis.xaml
    /// </summary>
    public partial class CreateDevis : Page
    {
        GammesEntity gammesDevis = new GammesEntity();

        ComposantsEntity compIsolation = new ComposantsEntity();
        ComposantsEntity compCouverture = new ComposantsEntity();

        public ObservableCollection<GammesEntity> listGamme { get; set; }
        public ObservableCollection<ComposantsEntity> listIsolant { get; set; }

        public CreateDevis()
        {
            InitializeComponent();
            this.DataContext = this;
            BindGamme();
            BindIsolation();
        }
        public void goToSelectGamme(object sender, RoutedEventArgs e)
        {
            creerDevis.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Visible;
        }

        public void goToSelectFinition(object sender, RoutedEventArgs e)
        {
            gammesDevis.Gam_Nom = ChoisirGamme.SelectedItem.ToString();

            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Visible;
        }

        public void goToSelectModele(object sender, RoutedEventArgs e)
        {
            compIsolation = (ComposantsEntity)ChoisirTypeIsolant.SelectedItem;
            compCouverture = (ComposantsEntity)ChoisirTypeCouverture.SelectedItem;

            selectFinition.Visibility = Visibility.Hidden;
            selectModele.Visibility = Visibility.Visible;
        }

        public void goToSelectPieces(object sender, RoutedEventArgs e)
        {
            selectModele.Visibility = Visibility.Hidden;
            selectPieces.Visibility = Visibility.Visible;
        }

        public void goToSelectClient(object sender, RoutedEventArgs e)
        {
            selectPieces.Visibility = Visibility.Hidden;
            selectClient.Visibility = Visibility.Visible;
        }

        public void goToSelectPaiement(object sender, RoutedEventArgs e)
        {
            selectClient.Visibility = Visibility.Hidden;
            selectPaiement.Visibility = Visibility.Visible;
        }

        public void goToDemonstration(object sender, RoutedEventArgs e)
        {
            selectPaiement.Visibility = Visibility.Hidden;
            selectDemonstration.Visibility = Visibility.Visible;
        }

        public void goToEnvoi(object sender, RoutedEventArgs e)
        {
            selectDemonstration.Visibility = Visibility.Hidden;
            selectEnvoi.Visibility = Visibility.Visible;
        }

        public void goToFinish(object sender, RoutedEventArgs e)
        {
            selectEnvoi.Visibility = Visibility.Hidden;
        }

        private void BindGamme()
        {
            listGamme = new ObservableCollection<GammesEntity>();
            GammesBLL games = new GammesBLL();
            listGamme = new ObservableCollection<GammesEntity>(games.selectAllGames());
        }
        private void BindIsolation()
        {
            listIsolant = new ObservableCollection<ComposantsEntity>();
            ComposantsBLL composants = new ComposantsBLL();
            listIsolant = new ObservableCollection<ComposantsEntity>(composants.getIsolationComposant());
        }

        private void BindCouverture()
        {
            listIsolant = new ObservableCollection<ComposantsEntity>();         
            ComposantsBLL composants = new ComposantsBLL();
            listIsolant = new ObservableCollection<ComposantsEntity>(composants.getCouvertureComposant());
        }
    }
}
