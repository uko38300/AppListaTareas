using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AppListaTareas.MVVM.Models;
using AppListaTareas.MVVM.Views;

namespace AppListaTareas.MVVM.ViewModels
{
    public class DataViewModel
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public DataViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>
            {
                new TaskItem

                     {
                         NameTask = "Lista tareas",
                         ImageSubject = "di.png",
                         Description = "Práctica entregable app de lista de tareas",
                         ImportanceClassification = 8,
                         DeliveryDate = new DateTime(2024, 12, 8),
                         TaskCompletes = false,
                         PendingTask = true,

                     },
                     new TaskItem
                     {
                         NameTask = "El Quijote",
                         ImageSubject = "ad.png",
                         Description = "Práctica entregable para hacer métodos con el libro de El Quijote",
                         ImportanceClassification = 6,
                         DeliveryDate = new DateTime(2024, 12, 12),
                         TaskCompletes = false,
                         PendingTask = true,
                     },
                     new TaskItem

                     {
                         NameTask = "Hilos",
                         ImageSubject = "psp.png",
                         Description = "Hilos con semáforo",
                         ImportanceClassification = 7,
                         DeliveryDate = new DateTime(2024, 11, 10),
                         TaskCompletes = true,
                         PendingTask = false,

                     },
                     new TaskItem
                     {
                         NameTask = "Odoo",
                         ImageSubject = "sge.png",
                         Description = "Entregar pdf con todos los pasos a seguir para Odoo",
                         ImportanceClassification = 6,
                         DeliveryDate = new DateTime(2024, 11, 15),
                         TaskCompletes = false,
                         PendingTask = true,
                     },
                     new TaskItem

                     {
                         NameTask = "Proyecto empresa",
                         ImageSubject = "eie.png",
                         Description = "Primera parte del proyecto de empresa",
                         ImportanceClassification = 8,
                         DeliveryDate = new DateTime(2024, 12, 20),
                         TaskCompletes = false,
                         PendingTask = true,

                     },
                     new TaskItem
                     {
                         NameTask = "Manual proyecto",
                         ImageSubject = "proy.png",
                         Description = "Documentación rellenada del manual del proyecto",
                         ImportanceClassification = 6,
                         DeliveryDate = new DateTime(2024, 02, 01),
                         TaskCompletes = false,
                         PendingTask = true,
                     },
               };

            //INICIALIZO LOS COMANDOS
            EditCommand = new Command<TaskItem>(OnEditTask);
            RemoveCommand = new Command<TaskItem>(OnRemoveTask);
            AddTaskCommand = new Command(OpenAddTaskView);

        }

        /*Método para eliminar tarea
         * 
         */
        public void RemoveTask(TaskItem task)
        {
            if (Tasks.Contains(task))
            {
                Tasks.Remove(task);
            }
        }

        /* Método para editar tarea
         * 
         */
        public void EditTask(TaskItem task, string newName, string newDescription, int newImportance,
            DateTime newDate, bool isComplete, bool isPending)
        {
            var existingTask = Tasks.FirstOrDefault(t => t == task);
            if (existingTask != null)
            {
                existingTask.NameTask = newName;
                existingTask.Description = newDescription;
                existingTask.ImportanceClassification = newImportance;
                existingTask.DeliveryDate = newDate;
                existingTask.TaskCompletes = isComplete;
                existingTask.PendingTask = isPending;
            }
        }


        //DECLARO LAS PROPIEDADES DE LOS COMANDOS
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand AddTaskCommand { get; }

        public void UpdateTask(TaskItem task, string name, string description, int importance, DateTime date, bool isComplete, bool isPending)
        {
            EditTask(task, name, description, importance, date, isComplete, isPending);
        }

        private async void OnEditTask(TaskItem task)
        {
            if (task != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditTaskPage(this, task));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo cargar la tarea", "OK");
            }
        }

        private void OnRemoveTask(TaskItem task)
        {
            RemoveTask(task);
        }

        private async void OpenAddTaskView()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddTaskView(this));
        }

    }


}



