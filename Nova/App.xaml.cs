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
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();

            _navigationBarViewModel = new NavigationBarViewModel(
                CreateSelectFilesNavigationService(),
                CreateHomeNavigationService(),
                CreateDataEntryNavigationService()
            );
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(_navigationStore,
                () => new HomeViewModel(_navigationStore, _navigationBarViewModel));
        }

        private NavigationService<SelectFilesViewModel> CreateSelectFilesNavigationService()
        {
            return new NavigationService<SelectFilesViewModel>(_navigationStore,
                () => new SelectFilesViewModel(_navigationStore, _navigationBarViewModel));
        }

        private NavigationService<DataEntryViewModel> CreateDataEntryNavigationService()
        {
            return new NavigationService<DataEntryViewModel>(_navigationStore,
                () => new DataEntryViewModel(new List<FileItem>(), _navigationStore, _navigationBarViewModel));
        }
    }
}