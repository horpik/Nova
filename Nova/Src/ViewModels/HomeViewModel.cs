using System.Windows.Input;
using Nova.Commands;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateSelectFilesCommand { get; }

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public HomeViewModel(NavigationStore navigationStore, NavigationBarViewModel navigationBarViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            NavigateSelectFilesCommand = new NavigateCommand<SelectFilesViewModel>(
                new NavigationService<SelectFilesViewModel>(navigationStore,
                    () => new SelectFilesViewModel(navigationStore, navigationBarViewModel)));
        }
    }
}