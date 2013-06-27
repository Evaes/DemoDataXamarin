using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace QNHDemo.WPGUI
{
    public partial class List : PhoneApplicationPage
    {
        string token = null;

        public List()
        {
            InitializeComponent();

            token = (string)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["token"];

            Loaded += List_Loaded;
        }

        void List_Loaded(object sender, RoutedEventArgs e)
        {
            _GetAllBooks();
        }

        /// <summary>
        /// Gets all books from web service
        /// </summary>
        private void _GetAllBooks()
        {
            QNHDemo.WP.ijMobile.JMobileSoapClient client = new QNHDemo.WP.ijMobile.JMobileSoapClient("IJMobileSoap", "https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx");

            client.GeefCaseLoadCompleted += client_GeefCaseLoadCompleted;

            client.GeefCaseLoadAsync(token);
        }

        /// <summary>
        /// event when the sync for caseload is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_GeefCaseLoadCompleted(object sender, WP.ijMobile.GeefCaseLoadCompletedEventArgs e)
        {
            lbxJeugdigen.ItemsSource = e.Result.Jeugdigen.ToList();
        }
    }
}