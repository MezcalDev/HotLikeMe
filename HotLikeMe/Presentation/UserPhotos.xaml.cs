using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace HotLikeMe
{
	public partial class UserPhotos : ContentPage
	{
		public  List<int> indexList= new List<int>();
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
					var tapGestureRecognizer = new TapGestureRecognizer ();
					tapGestureRecognizer.Tapped += (imageSource, eventArgs) =>
					
					{
						bool selected = false;
						for(int i = 0; i < indexList.Count; i++)
						{	
							
							int selectedImage = indexList[i];
							if(selectedImage == index)
							{
							selected = true;
							}

						}

						if (selected)
						{
							ViewExtensions.RotateTo(imageSource as Image, 0, 500,Easing.SinOut);	
							indexList.Remove(index);

						}else

						{
							ViewExtensions.RotateTo(imageSource as Image, 15.0, 500,Easing.SinOut);
							indexList.Add(index);
						}
					};

					image.GestureRecognizers.Add (tapGestureRecognizer);
				}
			};
			var scroll = new ScrollView ();
			scroll.Content = grid;
			//this.Content = scroll;
			Button button = new Button 
			{
				Text = "Done",
				BackgroundColor = Color.Red,
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BorderRadius = 40,
			};

			button.Clicked += button_Clicked;
			this.Content = new StackLayout 
			{
				Children =
				{
					button,	
					scroll
				}
			};
		}

		public void button_Clicked (object sender, EventArgs e)
		{
			var client = DependencyService.Get<IMobileClient> ();
			for (int i = 0; i < indexList.Count; i++) 
			{	
				
				int index = indexList[i];
				var selectPhoto = source.GetPhoto (index);  
				client.GetHDImage (selectPhoto);

				//toDo : agregar try catch para verificar que se suban correctamente las fotos 

			}
		}
	}
}
	
