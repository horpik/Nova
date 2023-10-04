using System.Collections.Generic;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class SelectFilesViewModel : ViewModelBase
    {
        public ICommand SelectAllFilesCommand { get; }

        public List<FileItem> FileItems { get; }

        public SelectFilesViewModel(FilesStore filesStore, INavigationService navigationService)
        {
            FileItems = new List<FileItem>(filesStore.FileItems);

            SelectAllFilesCommand = new SelectAllFilesCommand(filesStore, navigationService);
        }
    }
}