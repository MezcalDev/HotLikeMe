using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HotLikeMe
{
	public partial class Main : ContentPage
	{
		public Main ()
		{
		
			InitializeComponent ();
			this. btnLogin.Clicked += async (sender, e) => {
				await Navigation.PushAsync(new Login());
		}
	}
}

