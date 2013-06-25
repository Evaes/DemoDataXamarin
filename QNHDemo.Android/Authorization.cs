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

namespace QNHDemo.Android
{
	public class Authorization
	{
		public static ijmobile.bjzlimburg.nl.LoginResultaat Login(string username, string password, string deviceId) {
			using(ijmobile.bjzlimburg.nl.IJMobile client = new QNHDemo.Android.ijmobile.bjzlimburg.nl.IJMobile("https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx")) {
				return client.Login(username, password, deviceId);
			}
		}

		public static string test(){
			using (ijmobile.bjzlimburg.nl.ArrayOfJeugdigenJeugdigeRelatieRelatie cl = new QNHDemo.Android.ijmobile.bjzlimburg.nl.ArrayOfJeugdigenJeugdigeRelatieRelatie()) {
				return cl.Naam;
			}
		}

	}
}

