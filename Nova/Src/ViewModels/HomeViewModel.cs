using System.Windows.Input;
using Nova.Commands;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateSelectFilesCommand { get; }

        public HomeViewModel(INavigationService navigationService)
        {
            NavigateSelectFilesCommand = new NavigateCommand<SelectFilesViewModel>(navigationService);
        }
    }
}