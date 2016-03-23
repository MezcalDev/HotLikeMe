using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotLikeMe
{
	public class FBImageSource
	{ 

		List<FBPhoto> photos = new List<FBPhoto> ();

		public FBImageSource (IDictionary <string, Object> jsonResult)
		{
			
			dynamic data = jsonResult ["data"];
			foreach (dynamic imageDictionary in data){
				photos.Add (new FBPhoto (imageDictionary ["id"], imageDictionary ["picture"]));
			}													
		}
		public int PhotoCount(){
			return photos.Count;
				
		}

		public FBPhoto GetPhoto(int index){
			return photos[index];
		}


		 
	}
}

