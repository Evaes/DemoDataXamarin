using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml;
using System.IO.IsolatedStorage;
using System.Threading;

namespace QNHDemo.WPGUI
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(username)) errors.Add("Voer een geldig gebruikersnaam adres in.");
            if (string.IsNullOrWhiteSpace(password)) errors.Add("Voer een geldig wachtwoord in. ");

            if (errors.Count > 0) lblError.Text = string.Join("\r\n", errors);
            else
            {
                //QNHDemo.WP.Authorization.Login(username, password, null, out resultName, out resultToken);

                _Login(username, password);
            }
        }

        /// <summary>
        /// login method
        /// </summary>
        /// <param name="username">the username</param>
        /// <param name="password">the password</param>
        /// <created>Timo</created>
        private void _Login(string username, string password)
        {
            QNHDemo.WP.ijMobile.JMobileSoapClient client = new QNHDemo.WP.ijMobile.JMobileSoapClient("IJMobileSoap", "https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx");

            client.LoginCompleted += client_LoginCompleted;

            client.LoginAsync(username, password, null);

            lblError.Text = "Trying to log in...";
        }

        /// <summary>
        /// Event for when login is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_LoginCompleted(object sender, WP.ijMobile.LoginCompletedEventArgs e)
        {
            var result = e.Result;

            if (result.Status != WP.ijMobile.LoginStatus.Succes)
            {
                lblError.Text = "login failed";
            }
            else
            {
                lblError.Text = "login success";
                Thread.Sleep(1000);

                if (!IsolatedStorageSettings.ApplicationSettings.Contains("token"))
                {
                    IsolatedStorageSettings.ApplicationSettings.Add("token", result.Token);
                }

                NavigationService.Navigate(new Uri("/List.xaml", UriKind.Relative));
            }
        }
    }
}