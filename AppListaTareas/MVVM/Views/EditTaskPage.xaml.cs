using AppListaTareas.MVVM.Models;
using AppListaTareas.MVVM.ViewModels;

namespace AppListaTareas.MVVM.Views;

public partial class EditTaskPage : ContentPage
{

    private DataViewModel _viewModel;
    private TaskItem _task;

    public EditTaskPage(DataViewModel viewModel, TaskItem task)
    {

        InitializeComponent();

        _viewModel = viewModel;
        _task = task;

        BindingContext = this;

        TaskCompletePicker.SelectedItem = task.TaskCompletes ? "Sí" : "No";
        TaskPendingPicker.SelectedItem = task.PendingTask ? "Sí" : "No";
    }

    private void SaveButton_Clicked(System.Object sender, System.EventArgs e)
    {
        bool isComplete = TaskCompletePicker.SelectedItem?.ToString() == "Sí";
        bool isPending = TaskPendingPicker.SelectedItem?.ToString() == "Sí";

        // Actualizar la tarea con los nuevos valores
        _task.NameTask = TaskNameEntry.Text;
        _task.Description = TaskDescriptionEntry.Text;
        _task.ImportanceClassification = int.Parse(TaskImportanceEntry.Text);
        _task.DeliveryDate = TaskDatePicker.Date;
        _task.TaskCompletes = isComplete;
        _task.PendingTask = isPending;

        // Llamar al método de actualización en el modelo de vista
        _viewModel.UpdateTask(
            _task,
            _task.NameTask,
            _task.Description,
            _task.ImportanceClassification,
            _task.DeliveryDate,
            _task.TaskCompletes,
            _task.PendingTask
        );

        // Regresar a la página anterior
        Navigation.PopAsync();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
    }


}
