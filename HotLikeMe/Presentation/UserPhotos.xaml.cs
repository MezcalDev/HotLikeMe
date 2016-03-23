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

		protected override void OnAppearing()
		{
			/*for (int index=0; index<source.PhotoCount(); index++)
			{
				FBPhoto photo = source.GetPhoto (index);
			}				
			base.OnAppearing ();*/	
			//Image image = photo.GetImage ();
			//this.image.Source = ImageSource.FromUri (new Uri (photo.url));
			Grid();

		}

		public void Grid(){
			
			Grid grid = new Grid 
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
				} 	
			};
			
			int Row = source.PhotoCount() /3;
			int remeinder = source.PhotoCount() % 3;
			if (remeinder > 0) {
				Row = Row + 1;
			}

			for(int x = 0; x < Row; x++)
			{				
				var RowDefinition = new RowDefinition {Height = new GridLength(130, GridUnitType.Absolute)};	

				grid.RowDefinitions.Add(RowDefinition);
	
				for(int y = 0; y < 3; y++)
				{					
					int index = x * 3 + y;
					if ( index >= source.PhotoCount())
					{
						break;
					}
					var image = new Image { Aspect = Aspect.AspectFill };
					FBPhoto photo = source.GetPhoto (index);
					image.Source = ImageSource.FromUri (new Uri (photo.url));
					grid.Children.Add(image ,y,x);			 
				}			
			};
			var scroll = new ScrollView ();
			scroll.Content = grid;
			this.Content = scroll;
		}	
	}
}

