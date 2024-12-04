using System;
using System.ComponentModel;

namespace AppListaTareas.MVVM.Models
{
    public class TaskItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nameTask = string.Empty;
        public string NameTask
        {
            get => _nameTask;
            set
            {
                if (_nameTask != value)
                {
                    _nameTask = value;
                    OnPropertyChanged(nameof(NameTask));
                }
            }
        }

        private string _imageSubject = string.Empty;
        public string ImageSubject
        {
            get => _imageSubject;
            set
            {
                if (_imageSubject != value)
                {
                    _imageSubject = value;
                    OnPropertyChanged(nameof(ImageSubject));
                }
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private int _importanceClassification;
        public int ImportanceClassification
        {
            get => _importanceClassification;
            set
            {
                if (_importanceClassification != value)
                {
                    _importanceClassification = value;
                    OnPropertyChanged(nameof(ImportanceClassification));
                }
            }
        }

        private DateTime _deliveryDate;
        public DateTime DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                if (_deliveryDate != value)
                {
                    _deliveryDate = value;
                    OnPropertyChanged(nameof(DeliveryDate));
                }
            }
        }

        private bool _taskCompletes;
        public bool TaskCompletes
        {
            get => _taskCompletes;
            set
            {
                if (_taskCompletes != value)
                {
                    _taskCompletes = value;
                    OnPropertyChanged(nameof(TaskCompletes));
                }
            }
        }

        private bool _pendingTask;
        public bool PendingTask
        {
            get => _pendingTask;
            set
            {
                if (_pendingTask != value)
                {
                    _pendingTask = value;
                    OnPropertyChanged(nameof(PendingTask));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

