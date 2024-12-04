using AppListaTareas.MVVM.Models;
using AppListaTareas.MVVM.ViewModels;

namespace AppListaTareas.MVVM.Views;

public partial class DataView : ContentPage
{
	public DataView()
	{
		InitializeComponent();
		
		BindingContext = new DataViewModel();
	}

	private async void OnEditTask(TaskItem task)
	{
		await Application.Current.MainPage.Navigation.PushAsync(new EditTaskPage(BindingContext as DataViewModel, task));
	}
}
