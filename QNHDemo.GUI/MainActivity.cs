using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace QNHDemo.GUI
{
	[Activity (Label = "QNHDemo.GUI", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.btnLogin);
            EditText username = FindViewById<EditText>(Resource.Id.tvUsername);
            EditText password = FindViewById<EditText>(Resource.Id.tvPassword);
			TextView tv = FindViewById<TextView> (Resource.Id.textView3);
			
			button.Click += delegate {
				//button.Text = string.Format ("{0} clicks!", count++);
                QNHDemo.Android.ijmobile.bjzlimburg.nl.LoginResultaat l = QNHDemo.Android.Authorization.Login(username.Text, password.Text, null);
				if(l.Status.ToString() == "Succes"){
					//var userActivity = new Intent(this, typeof(UserActivity));
					String r = QNHDemo.Android.Authorization.test();
					tv.Text = r;
					//StartActivity(userActivity);
				} else {
					tv.Text = l.Status.ToString();
				}
			};
		}
	}
}


