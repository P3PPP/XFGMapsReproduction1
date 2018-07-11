using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NullMyLocationButtonEnabled
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var button = new Button
			{
				Text = "Go to map",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};

			var menuPage = new ContentPage
			{
				Content = button,
			};

			button.Clicked += (s, e) =>
			{
				var nextPage = new MainPage
				{
					BindingContext = new MainPageViewModel { MyLocationButtonEnabled = true },

				};
				menuPage.Navigation.PushAsync(nextPage);
			};

			var naviPage = new NavigationPage(menuPage);
			naviPage.Popped += (s, e) =>
			{
				try
				{
					// [iOS] Pop時にBindingContextをnullクリアするとXF GoogleMapsで死ぬ。
					// このようなnullクリアはPrism.Formsで行われている。
					// PoppedイベントがPageのDispose後に実行されていると思うの、その辺が怪しい？
					e.Page.BindingContext = null;
				}
				catch(Exception ex)
				{
					// 何故かここでは捕捉できずに、iOSのApplication.Main()まで突き抜ける。
					System.Diagnostics.Debug.WriteLine(ex);
					throw;
				}
			};

			MainPage = naviPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
