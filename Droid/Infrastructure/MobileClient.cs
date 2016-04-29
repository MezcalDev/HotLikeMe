using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using HotLikeMe;
using Newtonsoft.Json.Linq;
using HotLikeMe.Droid;
using Xamarin.Forms;
using Facebook;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;



[assembly: Xamarin.Forms.Dependency (typeof(MobileClient))]
namespace HotLikeMe.Droid
{
	public class MobileClient : IMobileClient
	{
		private string access_token = null;
		private string connection_string= null;

		public MobileClient ()
		{
			
		}
		MobileServiceUser user;
		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider, JObject token){
			user = await ((HotLikeMe.App)App.Current).Client.LoginAsync (Xamarin.Forms.Forms.Context ,provider);
			return user;
		}

		private async Task<string> GetToken(){
			//return "CAACEdEose0cBALwXWVZCAL1gZAJ54PY4nZBzcZCfs9fbVOuDr8d9InK9MMTFbJEZAH0AlRQ80sk5DIjZCo3p3nEpyf1Y6QMXnhK10hP49w80ibqUK5S6RDqFhggNEO3jdam3LDLepWa9mnqnnkbTxhZBR9bORcEHp7EZBMZBF5FL5FpyQJH3oGPpZCnWxTRCs21NjOoLr9ZCK1zcQZDZD";
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

		public async Task<FBImageSource> GetImages(){
			var access_token = await GetToken ();
			FacebookClient fb = new FacebookClient (access_token);
			dynamic result = await fb.GetTaskAsync ("me/photos", new {fields = "picture"});
			var source = new HotLikeMe.FBImageSource (result);
			return source;

			 
		}
		public async void GetHDImage(FBPhoto photo){
			var access_token = await GetToken ();
			FacebookClient fb = new FacebookClient (access_token);
			dynamic result = await fb.GetTaskAsync (photo.id, new {fields = "image"});
		}

		public async Task<string> GetConectionString (){
			if (connection_string != null) 
			{
				return connection_string;

			}else{
				JToken conectionString = await((HotLikeMe.App)App.Current).Client.InvokeApiAsync ("get_storage_conection_string", System.Net.Http.HttpMethod.Get, null);
				var inner = conectionString ["connection_string"];
				connection_string = inner.ToString();			
				return connection_string;
			}
		}

		public async Task<string> GetSAS(){	
			JToken getSAS = await((HotLikeMe.App)App.Current).Client.InvokeApiAsync (
				"get_sas", System.Net.Http.HttpMethod.Get, null);
			var inner = getSAS ["sas"];
			return inner.ToString();
			 
		}

		public async Task<string> UploadPhoto(){			
			string fullPath;
			string sas = "https://hotlikeme.blob.core.windows.net/images?"+(await GetSAS ()).ToString ();
			CloudBlobContainer container = new CloudBlobContainer(new Uri(sas));
			CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");
			string blobContent = "This blob will be accessible to clients via a shared access signature. " +
				"A stored access policy defines the constraints for the signature.";
			MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(blobContent));
			ms.Position = 0;
			using (ms)				
			{
				blockBlob.UploadFromStream(ms);	
			};	
			var uri = new UriBuilder (blockBlob.Uri);
			uri.Scheme = "https";
			fullPath = uri.ToString ();
			return fullPath;

			 
		}
	}
}

