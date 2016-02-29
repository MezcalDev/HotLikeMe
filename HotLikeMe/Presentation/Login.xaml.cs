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
		async void OnLoginClicked (object sender, EventArgs e){
			MobileServiceUser user;

			user = await DependencyService.Get<IMobileClient> ()
				.LoginAsync (MobileServiceAuthenticationProvider.Facebook);
		
		}


		public async Task<MobileServiceUser> LoginAync(MobileServiceAuthenticationProvider provider)
		{
			return await App.Client.LoginAsync (Forms.context, provider);
		}

	
	}
}

