using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace QNHDemo.WP.Service
{
    /// <summary>
    /// Class for caseloadweb. This will call web service 
    /// </summary>
    internal class CaseLoadWeb
    {
        public static List<QNHDemo.Data.Entities.Jeugdige> GetCaseLoad(string token)
        {
            var result = new List<QNHDemo.Data.Entities.Jeugdige>();
            QNHDemo.WP.ijMobile.JMobileSoapClient client = new QNHDemo.WP.ijMobile.JMobileSoapClient("IJMobileSoap", "https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx");

            Exception error = null;
            ijMobile.CaseloadResult webResult = null;

            client.GeefCaseLoadCompleted += (sender, e) =>
            {
                error = e.Error;
                webResult = e.Result;
            };

            client.GeefCaseLoadAsync(token);

            //wait till the result has been fetched
            //do
            //{
            //    Thread.Sleep(500);
            //} while (webResult == null);

            //convert to app list
            foreach (var item in webResult.Jeugdigen)
            {
                result.Add(new Data.Entities.Jeugdige
                {
                    Id = item.Id,
                    Name = item.Naam
                });
            }

            //save the xml
            System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Add("jeugdige", QNHDemo.Data.DAL.Dal.SerializeObject<List<QNHDemo.Data.Entities.Jeugdige>>(result));

            return result;
        }

    }
}
