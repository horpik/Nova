using System.Collections.Generic;
using System.Windows;
using Nova.Models;
using Nova.Services;
using Nova.Stores;
using Nova.ViewModels;

namespace Nova
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly NavigationStore _navigationStore;
        private readonly FilesStore _filesStore;

        public App()
        {
            _filesStore = new FilesStore();
            _navigationStore = new NavigationStore();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(CreateSelectFilesNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<SelectFilesViewModel> CreateSelectFilesNavigationService()
        {
            return new LayoutNavigationService<SelectFilesViewModel>(
                _navigationStore,
                () => new SelectFilesViewModel(_filesStore, CreateDataEntryNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<DataEntryViewModel> CreateDataEntryNavigationService()
        {
            return new LayoutNavigationService<DataEntryViewModel>(
                _navigationStore,
                () => new DataEntryViewModel(_filesStore, CreateHomeNavigationService()),
                CreateNavigationBarViewModel);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreateSelectFilesNavigationService(),
                CreateHomeNavigationService(),
                CreateDataEntryNavigationService()
            );
        }
    }
}