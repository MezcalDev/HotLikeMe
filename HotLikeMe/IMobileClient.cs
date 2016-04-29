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
		Task<String> GetConectionString();
		Task<FBImageSource> GetImages();
		Task <String> GetSAS();
		void GetHDImage(FBPhoto photo);
		Task <String> UploadPhoto();



	}
}

