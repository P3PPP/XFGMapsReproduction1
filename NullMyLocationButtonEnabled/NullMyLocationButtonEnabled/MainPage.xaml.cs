using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace NullMyLocationButtonEnabled
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			_map.UiSettings.SetBinding(BindableObject.BindingContextProperty,
				new Binding(BindableObject.BindingContextProperty.PropertyName, source: this));

			_map.UiSettings.SetBinding(
				UiSettings.MyLocationButtonEnabledProperty,
				"MyLocationButtonEnabled");
		}
	}

	public class MainPageViewModel
	{
		public bool MyLocationButtonEnabled { get; set; }
	}
}
