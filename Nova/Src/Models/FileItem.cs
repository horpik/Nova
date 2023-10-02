using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Nova.Models
{
    public class FileItem : INotifyPropertyChanged
    {
        public string FileName { get; }
        public string FilePath { get; }
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public FileItem(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
            IsSelected = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}