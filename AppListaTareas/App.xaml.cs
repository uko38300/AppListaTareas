using AppListaTareas.MVVM.Views;

namespace AppListaTareas;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage (new DataView());
		
	}
}

