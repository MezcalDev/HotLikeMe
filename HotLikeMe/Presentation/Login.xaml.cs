using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace HotLikeMe
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		async void OnLogin (object sender, EventArgs e){
			
			MobileServiceUser user;// = new MobileServiceUser("FAKE");
			var client = DependencyService.Get<IMobileClient> ();
			user = await client.LoginAsync (MobileServiceAuthenticationProvider.Facebook, null);
			if (user == null)
			{
				return ;
			}
			var source = await client.GetImages();
			await this.Navigation.PushModalAsync (new UserPhotos(source));

		}

	}
}




