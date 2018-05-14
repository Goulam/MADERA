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
using Web_Service.Controller;
using Web_Service.Entity;

namespace Madera
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        CommerciauxEntity commercial;
        GammesEntity gammesDevis = new GammesEntity();
        public List<GammesEntity> listGamme ;

        public Dashboard()
        {
            InitializeComponent();
            listGamme = new List<GammesEntity>();
            GammesController games = new GammesController();

            listGamme = games.selectAllGames();
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
            enregistrerClient.Visibility = Visibility.Hidden;
            succesSaveClient.Visibility = Visibility.Hidden;
            searchClient.Visibility = Visibility.Hidden;
            modifierClient.Visibility = Visibility.Hidden;
            creerDevis.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Hidden;
            selectModele.Visibility = Visibility.Hidden;
            selectPieces.Visibility = Visibility.Hidden;
            selectClient.Visibility = Visibility.Hidden;
            selectPaiement.Visibility = Visibility.Hidden;
            selectDemonstration.Visibility = Visibility.Hidden;
            selectEnvoi.Visibility = Visibility.Hidden;
        }

        public void goToSearchClient(object sender, RoutedEventArgs e)
        {
            enregistrerClient.Visibility = Visibility.Hidden;
            succesSaveClient.Visibility = Visibility.Hidden;
            modifierClient.Visibility = Visibility.Hidden;
            searchClient.Visibility = Visibility.Visible;
            creerDevis.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Hidden;
            selectModele.Visibility = Visibility.Hidden;
            selectPieces.Visibility = Visibility.Hidden;
            selectClient.Visibility = Visibility.Hidden;
            selectPaiement.Visibility = Visibility.Hidden;
            selectDemonstration.Visibility = Visibility.Hidden;
            selectEnvoi.Visibility = Visibility.Hidden;


            ClientController clientControl = new ClientController();
            clientList.ItemsSource = clientControl.getAll();
        }

        public void goToCreateDevis(object sender, RoutedEventArgs e)
        {
            creerDevis.Visibility = Visibility.Visible;
            enregistrerClient.Visibility = Visibility.Hidden;
            succesSaveClient.Visibility = Visibility.Hidden;
            searchClient.Visibility = Visibility.Hidden;
            modifierClient.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Hidden;
            selectModele.Visibility = Visibility.Hidden;
            selectPieces.Visibility = Visibility.Hidden;
            selectClient.Visibility = Visibility.Hidden;
            selectPaiement.Visibility = Visibility.Hidden;
            selectDemonstration.Visibility = Visibility.Hidden;
            selectEnvoi.Visibility = Visibility.Hidden;
        }

        public void goToSelectGamme(object sender, RoutedEventArgs e)
        {
            creerDevis.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Visible;

            //foreach(var item in listGamme)
            //{
            //    ChoisirGamme.Items.Add(item);
            //}

        }
     

        public void goToSelectFinition(object sender, RoutedEventArgs e)
        {
            gammesDevis.Gam_Nom = ChoisirGamme.SelectedItem.ToString();

            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Visible;

        }
        public void goToSelectModele(object sender, RoutedEventArgs e)
        {
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

        public void goToCreateClient(object sender, RoutedEventArgs e)
        {
            enregistrerClient.Visibility = Visibility.Visible;
            succesSaveClient.Visibility = Visibility.Hidden;
            searchClient.Visibility = Visibility.Hidden;
            modifierClient.Visibility = Visibility.Hidden;
            creerDevis.Visibility = Visibility.Hidden;
            selectGamme.Visibility = Visibility.Hidden;
            selectFinition.Visibility = Visibility.Hidden;
            selectModele.Visibility = Visibility.Hidden;
            selectPieces.Visibility = Visibility.Hidden;
            selectClient.Visibility = Visibility.Hidden;
            selectPaiement.Visibility = Visibility.Hidden;
            selectDemonstration.Visibility = Visibility.Hidden;
            selectEnvoi.Visibility = Visibility.Hidden;

        }

        public void updateSearch(object sender, RoutedEventArgs e)
        {
            ClientController clientControl = new ClientController();

            if(inputSearchClient.Text.Length > 0)
            {
                clientList.ItemsSource = clientControl.getSearchAll(inputSearchClient.Text);
            }
        }

        public void saveClient(object sender, RoutedEventArgs e)
        {
            ClientEntity client = new ClientEntity();

            if (inputNom.Text != "" && inputPrenom.Text != "" && inputPhone.Text != "" && inputEmail.Text != "")
            {
                client.Cli_Nom = inputNom.Text;
                client.Cli_Prenom = inputPrenom.Text;
                client.Cli_Phone = inputPhone.Text;
                client.Cli_Email = inputEmail.Text;

                client.Cli_Adresse = inputAdresse1.Text;
                client.Cli_Ville = inputVille.Text;
                client.Cli_CP = inputCP.Text;
                try
                {
                    ClientController controlClient = new ClientController();
                    controlClient.createClient(client);
                    enregistrerClient.Visibility = Visibility.Hidden;
                    succesSaveClient.Visibility = Visibility.Visible;
                }
                catch (Exception error)
                {

                }
            }
            else
            {

            }
        }

        public void goToModifyClient(object sender, RoutedEventArgs e)
        {
            searchClient.Visibility = Visibility.Hidden;
            modifierClient.Visibility = Visibility.Visible;

            ClientEntity clientUpdte = (ClientEntity)clientList.SelectedItem;


            modifyNom.Text = clientUpdte.Cli_Nom;
            modifyPrenom.Text = clientUpdte.Cli_Prenom;
            modifyPhone.Text = clientUpdte.Cli_Phone;
            modifyEmail.Text = clientUpdte.Cli_Email;
            modifyAdresse1.Text = clientUpdte.Cli_Adresse;
            modifyVille.Text = clientUpdte.Cli_Ville;
            modifyCP.Text = clientUpdte.Cli_CP;
            idModifyClient.Text = clientUpdte.Cli_Index.ToString();

        }

        public void sendModifyClient(object sender, RoutedEventArgs e)
        {
            ClientEntity clientUpdte = new ClientEntity();

            clientUpdte.Cli_Nom = modifyNom.Text;
            clientUpdte.Cli_Prenom = modifyPrenom.Text;
            clientUpdte.Cli_Phone = modifyPhone.Text;
            clientUpdte.Cli_Email = modifyEmail.Text;
            clientUpdte.Cli_Adresse = modifyAdresse1.Text;
            clientUpdte.Cli_Ville = modifyVille.Text;
            clientUpdte.Cli_CP = modifyCP.Text;
            clientUpdte.Cli_Actif = 1;
            clientUpdte.Cli_Index = Int32.Parse(idModifyClient.Text);

            ClientController controlClt = new ClientController();

            try
            {
                controlClt.updateClient(clientUpdte);
                modifierClient.Visibility = Visibility.Hidden;
                succesModifyClient.Visibility = Visibility.Visible;
            }
            catch
            {
                modifierClient.Visibility = Visibility.Hidden;
                succesModifyClient.Visibility = Visibility.Hidden;
                erroHappen.Visibility = Visibility.Visible;
            }
        }

    }
}
