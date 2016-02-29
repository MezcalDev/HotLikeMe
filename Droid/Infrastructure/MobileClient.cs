using System;
using Microsoft.WindowsAzure.MobileServices;
using HotLikeMe;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HotLikeMe.Droid
{
	public class MobileClient : IMobileClient

	{
		public MobileClient ()
		{
			
				
		}

		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token){
			return await ((HotLikeMe.App)App.Current).Client.LoginAsync (provider,token);

		}
						
	}
}

