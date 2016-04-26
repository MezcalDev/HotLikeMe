using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;


namespace HotLikeMe
{

	public class FBPhoto
	{
		public string id;
		public string url;
		public string urlHD;

		public FBPhoto (string id,string url)
		{
			this.id = id;
			this.url = url;
		}

		List<FBPhoto> photos = new List<FBPhoto> ();
		public async void setImages (IDictionary <string, Object> jsonResult)
		{
			int max = 0;
			string maxUrl = null;
			dynamic data = jsonResult ["images"];
			dynamic result = await data.GetTaskAsync (id, new {fields = "images"});
			foreach (dynamic imageDictionary in data) {				
				int height = imageDictionary ["height"];
				if (height >= max) 
				{
					
					maxUrl = imageDictionary ["source"];
					max = height;

				}
			}
			maxUrl = urlHD;
					 
		}
	}
}
	