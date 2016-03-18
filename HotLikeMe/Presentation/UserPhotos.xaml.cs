using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HotLikeMe
{
	public partial class UserPhotos : ContentPage
	{
		FBImageSource source;

		public UserPhotos (FBImageSource source)
		{
			InitializeComponent ();
			this.source = source;
		}

		protected override void OnAppearing(){
			FBPhoto photo = source.GetPhoto();
			//Image image = photo.GetImage ();
			//this.image.Source = ImageSource.FromUri (new Uri (photo.url));

		}

	}
}

