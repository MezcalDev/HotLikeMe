using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Net;

using Xamarin.Forms;

namespace HotLikeMe
{
	public partial class Login : ContentPage
	{ 

		public class Constants
		{
			public const string UserNotFound = "The user doesn't exist";
		}

		public Login ()
		{
			InitializeComponent ();
		}
				 
		async void OnLogin (object sender, EventArgs args){
			MobileServiceUser user;

			user = await DependencyService.Get<IMobileClient>()
				.LoginAsync(MobileServiceAuthenticationProvider.Facebook, null);
									
			


		}
	}
}