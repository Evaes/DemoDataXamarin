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
				String xml = QNHDemo.Data.DAL.Dal.SerializeObject<List<QNHDemo.Data.Entities.Jeugdige>> (result);

				return result;
			}
		}
	}
}

