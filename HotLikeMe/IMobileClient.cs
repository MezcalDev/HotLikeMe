using System;
using Microsoft.WindowsAzure.MobileServices;
using HotLikeMe;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HotLikeMe
{
	public interface IMobileClient
	{
		Task<MobileServiceUser> LoginAsync (MobileServiceAuthenticationProvider provider, JObject token);
		Task<String> GetName();
		Task<FBImageSource> GetImage();

	}
}

