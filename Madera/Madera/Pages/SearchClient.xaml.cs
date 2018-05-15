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
    /// Logique d'interaction pour SearchClient.xaml
    /// </summary>
    public partial class SearchClient : Page
    {
        public SearchClient()
        {
            InitializeComponent();
            ClientController clientControl = new ClientController();
            clientList.ItemsSource = clientControl.getAll();
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

        public void updateSearch(object sender, RoutedEventArgs e)
        {
            ClientController clientControl = new ClientController();

            if (inputSearchClient.Text.Length > 0)
            {
                clientList.ItemsSource = clientControl.getSearchAll(inputSearchClient.Text);
            }
        }
    }
}
