﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using HotLikeMe;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using HotLikeMe.Droid;
using Xamarin.Forms;
using Facebook;
using System.Collections;
using Microsoft.CSharp;

[assembly: Xamarin.Forms.Dependency (typeof(MobileClient))]
namespace HotLikeMe.Droid
{
	public class MobileClient : IMobileClient
	{
		private string access_token = null;

		public MobileClient ()
		{
			
		}

		MobileServiceUser user;
		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token){
			user = await ((HotLikeMe.App)App.Current).Client.LoginAsync (Xamarin.Forms.Forms.Context ,provider);
			return user;

		} 
		private async Task<string> GetToken(){
			return "CAACEdEose0cBAKaFN55TqHk8SJhEOlH0g7VFsxEXypAMFzPyKZBH05qvYPvv9Pi6ZBhLQhdhcez29biqA0iFRbXj9mvPszAO5nYTKn2LLmH54HDZCLpxD6USWrYZBDAOxpcvvACUm3ZCWtPfwARwAB6oKvqdhl1ECRyKIeAr84KPp6lZAYBkTY03S19loAExZCFksPEm9NS0AZDZD";
			if (access_token != null){
				return access_token;

			} else {
				JToken outer = await ((HotLikeMe.App)App.Current).Client.InvokeApiAsync ("test", System.Net.Http.HttpMethod.Get, null);
				var stringValue = outer.ToString();
				var inner = outer ["facebook"];
				access_token = inner ["access_token"].ToString();			
				return access_token;
			}
		}

		public async Task<String> GetName() {
			
			var access_token = await GetToken ();
			FacebookClient fb = new FacebookClient(access_token);
			dynamic result = await fb.GetTaskAsync ("me");
			dynamic name = result ["name"];
			return name;
		}

		public async Task<FBImageSource> GetImage(){
			var access_token = await GetToken ();
			FacebookClient fb = new FacebookClient (access_token);
			dynamic result = await fb.GetTaskAsync ("me/photos", new {fields = "picture"});
			var source = new HotLikeMe.FBImageSource (result);
			return source;
		
		 
		} 

	}
}

