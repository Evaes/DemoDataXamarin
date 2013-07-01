using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace QNHDemo.WP
{
    public class Storage
    {
        IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();

        public static void StoreLogin(string name, string token) 
        {
            QNHDemo.Data.Entities.Gebruiker g = new Data.Entities.Gebruiker
            {
                Naam = name,
                Token = token
            };

            var xml = QNHDemo.Data.DAL.Dal.SerializeUser(g);

            IsolatedStorageSettings.ApplicationSettings.Remove("XmlStorage");
            IsolatedStorageSettings.ApplicationSettings.Add("XmlStorage", xml);
        }

        /// <summary>
        /// Retrieve token from xml 
        /// </summary>
        /// <returns>token</returns>
        public static string RetrieveToken() {
            string xml = (string)IsolatedStorageSettings.ApplicationSettings["XmlStorage"];

            var g = QNHDemo.Data.DAL.Dal.DeSerializeUser(xml);

            return g.Token;
        }

    }
}
