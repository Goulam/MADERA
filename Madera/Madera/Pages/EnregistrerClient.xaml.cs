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
    /// Logique d'interaction pour EnregistrerClient.xaml
    /// </summary>
    public partial class EnregistrerClient : Page
    {
        public EnregistrerClient()
        {
            InitializeComponent();
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
    }
    
}
