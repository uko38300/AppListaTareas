using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using AppListaTareas.MVVM.Models;

namespace AppListaTareas.MVVM.ViewModels
{
    public class AddTaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly DataViewModel _mainViewModel;
        public TaskItem NewTask { get; set; }
        public ICommand SaveCommand { get; }

        //las imágenes
        public ObservableCollection<string> SubjectImages { get; set; }

        private string selectedImage;

        public string SelectedImage
        {
            get => selectedImage;
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    NewTask.ImageSubject = selectedImage;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //añadir una nueva tarea
        public AddTaskViewModel(DataViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            NewTask = new TaskItem
            {
                DeliveryDate = DateTime.Now,
                ImportanceClassification = 1
            };
            SubjectImages = new ObservableCollection<string>
            {
                "ad.png",   // Acceso a Datos
                "di.png",   // Desarrollo de Interfaces
                "eie.png",  // Empresa e Iniciativa emprendedora
                "pmdm.png", // Programación Multimedia y Dispositivos Móviles
                "proy.png", // Proyecto
                "psp.png",  // Programación de Servicios y Procesos
                "sge.png"   // Sistema de Gestión Empresarial
            };

            SaveCommand = new Command(OnSaveTask);
        }

        private async void OnSave()
        {
            NewTask.ImageSubject = SelectedImage;

            if (ValidateTask(NewTask))
            {
                _mainViewModel.Tasks.Add(NewTask);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Complete todos los campos", "OK");
            }
        }

        private async void OnSaveTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTask.NameTask) && !string.IsNullOrWhiteSpace(NewTask.Description))
            {
                _mainViewModel.Tasks.Add(NewTask);
                await Application.Current.MainPage.Navigation.PopAsync(); // Regresar a la vista principal
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos obligatorios.", "OK");
            }
        }

        private bool ValidateTask(TaskItem task)
        {
            return !string.IsNullOrWhiteSpace(task.NameTask) &&
                   !string.IsNullOrWhiteSpace(task.Description) &&
                   task.ImportanceClassification > 0 &&
                   task.DeliveryDate != null &&
                   !string.IsNullOrEmpty(task.ImageSubject);
        }
    }
}

