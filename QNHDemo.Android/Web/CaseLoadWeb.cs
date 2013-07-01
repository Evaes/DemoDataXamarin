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

namespace QNHDemo.Android.Service
{
	public class CaseLoadWeb
	{
		public static List<Entities.Jeugdige> GetCaseLoad(string token) {
			using (ijmobile.bjzlimburg.nl.IJMobile client = new QNHDemo.Android.ijmobile.bjzlimburg.nl.IJMobile("https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx"))
			{
				var result = new List<Entities.Jeugdige>();

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

				return result;
			}
		}
	}
}

