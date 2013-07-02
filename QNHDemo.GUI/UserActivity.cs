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
using QNHDemo.Android;
using Java.IO;

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
           
            List<QNHDemo.Data.Entities.Jeugdige> caseLoadResult = QNHDemo.Web.CaseLoadWeb.GetCaseLoad(Intent.GetStringExtra("loginToken"));

            StringWriter writer = new StringWriter();

            namen = new string[caseLoadResult.Count];
            ListView l = FindViewById<ListView>(Resource.Id.listView1);
            for (int i = 0; i < caseLoadResult.Count; i++)
            {
                QNHDemo.Data.Entities.Jeugdige j = caseLoadResult[i];
                jeugdigen.Text += j.Name + "\r\n";
            }
        } 
	}
}

