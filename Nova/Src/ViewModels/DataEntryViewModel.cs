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
        public List<FileItem> FileItems;

        public DataEntryViewModel(NavigationStore navigationStore)
        {
            NavigateSelectFilesCommand = new NavigateCommand<SelectFilesViewModel>(
                new NavigationService<SelectFilesViewModel>(navigationStore,
                    () => new SelectFilesViewModel(navigationStore)));
        }
    }
}