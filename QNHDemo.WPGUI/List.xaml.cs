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
using System.Xml.Serialization;
using System.IO.IsolatedStorage;

namespace QNHDemo.WPGUI
{
    public partial class List : PhoneApplicationPage
    {
        string token = null;

        public List()
        {
            InitializeComponent();

            token = QNHDemo.WP.Storage.RetrieveToken();

            Loaded += List_Loaded;
        }

        void List_Loaded(object sender, RoutedEventArgs e)
        {
            string xml = null;

            //check if there already are jeugdige 
            if (IsolatedStorageSettings.ApplicationSettings.Contains("jeugdige"))
            {
                xml = (string)IsolatedStorageSettings.ApplicationSettings["jeugdige"];
                var result = QNHDemo.Data.CaseLoad.GetJeugdigen(xml, token);

                lbxJeugdigen.ItemsSource = result;
            }
            else
            {
                _GetWebData();
            }
        }

        private void _GetWebData()
        {
            QNHDemo.WP.ijMobile.JMobileSoapClient client = new QNHDemo.WP.ijMobile.JMobileSoapClient("IJMobileSoap", "https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx");

            client.GeefCaseLoadCompleted += client_GeefCaseLoadCompleted;

            client.GeefCaseLoadAsync(token);
        }

        /// <summary>
        /// Retrieves token from isolated storage
        /// </summary>
        /// <returns>the token</returns>
        private string _RetrieveTokenFromXml()
        {
            string result = "";

            string xml = (string)System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings["XmlStorage"];

            XmlReader reader = XmlReader.Create(new System.IO.StringReader(xml));

            while (reader.Read())
            {
                //start shit
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        //if all works, token should be in storage
                        case "storage":
                            result = reader["token"];

                            if (reader.Read())
                            {
                                result = reader.Value;

                                if (reader.Read())
                                {
                                    result = reader.Value;
                                }

                            }
                            break;
                        //default case sucks
                        default:
                            break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// event when the sync for caseload is complete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_GeefCaseLoadCompleted(object sender, WP.ijMobile.GeefCaseLoadCompletedEventArgs e)
        {
            var result = new List<QNHDemo.Data.Entities.Jeugdige>();


            //convert to app list
            foreach (var item in e.Result.Jeugdigen)
            {
                result.Add(new Data.Entities.Jeugdige
                {
                    Id = item.Id,
                    Name = item.Naam
                });
            }

            //save the xml
            System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Add("jeugdige", QNHDemo.Data.DAL.Dal.SerializeObject<List<QNHDemo.Data.Entities.Jeugdige>>(result));

            lbxJeugdigen.ItemsSource = result;


        }
    }
}