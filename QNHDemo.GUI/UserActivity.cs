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

namespace QNHDemo.GUI
{
	[Activity (Label = "UserActivity")]			
	public class UserActivity : Activity
	{
        string[] namen;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CaseLoad);
            TextView jeugdigen = FindViewById<TextView>(Resource.Id.tv_results);
            QNHDemo.Android.ijmobile.bjzlimburg.nl.CaseloadResult caseLoadResult = QNHDemo.Android.Authorization.test(Intent.GetStringExtra("loginToken"));

            if (caseLoadResult.Status.ToString() == "Ok")
            {
                namen = new string[caseLoadResult.Jeugdigen.Length];
                for (int i = 0; i < caseLoadResult.Jeugdigen.Length; i++)
                {
                    QNHDemo.Android.ijmobile.bjzlimburg.nl.JeugdigenJeugdige persoon = caseLoadResult.Jeugdigen[i];
                    namen[i] = persoon.Naam;
                }
            }
            for (int i = 0; i < namen.Length; i++)
            {
                jeugdigen.Text += namen[i] + "\r\n";
            }
        } 
	}
}

