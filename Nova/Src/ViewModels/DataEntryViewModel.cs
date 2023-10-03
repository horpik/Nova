using System.Collections.Generic;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateSelectFilesCommand { get; }

        private readonly List<FileItem> _fileItems;

        public List<FileItem> FileItems => new List<FileItem>(_fileItems);

        public DataEntryViewModel(FilesStore filesStore, INavigationService homeNavigationService)
        {
            _fileItems = filesStore.FileItems;
            NavigateSelectFilesCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}