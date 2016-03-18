using System;
using System.Collections;
using Xamarin.Forms;


namespace HotLikeMe
{
	public class FBPhoto
	{
		public string id;
		public string url;
		
		public FBPhoto (string id,string url)
		{
			this.id = id;
			this.url = url;
		}
		/*public Image GetImage(){
			var image = new Image { Aspect = Aspect.AspectFit };
			image.Source = ImageSource.FromUri (new Uri (url));
		}*/
	
	}
}
	