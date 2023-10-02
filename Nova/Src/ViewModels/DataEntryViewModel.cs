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

        public NavigationBarViewModel NavigationBarViewModel { get; }

        private readonly List<FileItem> _fileItems;

        public List<FileItem> FileItems => new List<FileItem>(_fileItems);

        public DataEntryViewModel(List<FileItem> fileItems, NavigationStore navigationStore,
            NavigationBarViewModel navigationBarViewModel)
        {
            _fileItems = fileItems;
            NavigationBarViewModel = navigationBarViewModel;
            NavigateSelectFilesCommand = new NavigateCommand<HomeViewModel>(
                new NavigationService<HomeViewModel>(navigationStore,
                    (() => new HomeViewModel(navigationStore, NavigationBarViewModel))));
        }
    }
}