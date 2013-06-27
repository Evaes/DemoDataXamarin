using System;
using System.Xml;

namespace QNHDemo.Data
{
	public class MyClass
	{
		public MyClass ()
		{
			var webClient = new WebClient ();
			webClient.DownloadStringCompleted += (sender, e) =>
			{
				var resultString = e.Result;
				// do something with downloaded string, do UI interaction on main thread
			};
			webClient.Encoding = System.Text.Encoding.UTF8;
			webClient.DownloadStringAsync (new Uri ("https://ijmobile.bjzlimburg.nl/ONTW/ijmobile.asmx?wsdl"));
		}
	}
}

