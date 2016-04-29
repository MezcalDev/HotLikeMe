using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;


namespace HotLikeMe
{
	public class App : Application
	{
		class Constants {

			public const string UserNotFound = "The user don't exist";
		}

		public MobileServiceClient Client = new MobileServiceClient("https://hotlikeme.azurewebsites.net");
		public App ()
		{
			MainPage = new Login ();
		}

		public String test;
		
 
		/*protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	  */

	}
}

