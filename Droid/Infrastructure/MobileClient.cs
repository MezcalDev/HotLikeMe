using System;
using Microsoft.WindowsAzure.MobileServices;
using HotLikeMe;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using HotLikeMe.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof(MobileClient))]
namespace HotLikeMe.Droid
{
	public class MobileClient : IMobileClient

	{
		public MobileClient ()
		{
			
		}
			
		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token){
			return await ((HotLikeMe.App)App.Current).Client.LoginAsync (Xamarin.Forms.Forms.Context ,provider);


		}
						
	}
}

