using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace QNHDemo.Web
{
	public class CaseLoadWeb
	{
		public static List<QNHDemo.Data.Entities.Jeugdige> GetCaseLoad(string token) {
			using (QNHDemo.Android.ijmobile.bjzlimburg.nl.IJMobile client = new QNHDemo.Android.ijmobile.bjzlimburg.nl.IJMobile("https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx"))
			{
				var result = new List<QNHDemo.Data.Entities.Jeugdige>();

				var webResult =  client.GeefCaseLoad(token);

				//convert to app list
				foreach (var item in webResult.Jeugdigen)
				{
					result.Add(new Data.Entities.Jeugdige
					           {
						Id = item.Id,
						Name = item.Naam
					});
				}

				//TODO: Schrijf de XML naar een bestand
				string xml = QNHDemo.Data.DAL.Dal.SerializeObject<List<QNHDemo.Data.Entities.Jeugdige>> (result);

                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                string filePath = Path.Combine(path, "jeugdige.xml");
                
                using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
                using (var strm = new StreamWriter(file))
                {
                    strm.Write(xml);
                }

                StreamReader files = File.OpenText(filePath);
                string f = files.ReadToEnd();

                return QNHDemo.Data.DAL.Dal.DeSerialize<List<QNHDemo.Data.Entities.Jeugdige>>(f);
			}
		}
	}
}

