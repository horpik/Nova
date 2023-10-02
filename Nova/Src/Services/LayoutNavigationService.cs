using System;
using Nova.Stores;
using Nova.ViewModels;

namespace Nova.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;
        private readonly Func<TViewModel> _createViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel,
            Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel =
                new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}