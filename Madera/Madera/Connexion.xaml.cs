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
using System.Security.Cryptography;

namespace Madera
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Connexion : Window
    {

        Dashboard myDashboard;
        CommerciauxEntity commercial;

        public Connexion()
        {
            InitializeComponent();
            myDashboard = new Dashboard();
        }

        void OnClickValidate(object sender, RoutedEventArgs e)
        {

            CommerciauxController commercialControl = new CommerciauxController();
            
            commercial = commercialControl.getActiveCommercialByEmail(inputId.Text);
            if(commercial == null)
            {
                errorText.Visibility = Visibility.Visible;
            }
            else
            {
                if (commercial.Com_Mdp == ConvertStringtoMD5(passwordBox.Password.ToString()))
                {
                    myDashboard.Show();
                    myDashboard.setCommercial(commercial);
                    this.Close();
                }
                else
                {
                    errorText.Visibility = Visibility.Visible;
                }
            }
            
        }

        public static string ConvertStringtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
