using AppListaTareas.MVVM.ViewModels;

namespace AppListaTareas.MVVM.Views;

public partial class AddTaskView : ContentPage
{
    private DataViewModel _viewModel;

    public AddTaskView(DataViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = new AddTaskViewModel(_viewModel);
	}

}
