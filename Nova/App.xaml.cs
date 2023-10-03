using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<FilesStore>();
            services.AddSingleton<NavigationStore>();

            services.AddSingleton<INavigationService>(CreateHomeNavigationService);

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigation = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigation.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => new HomeViewModel(CreateSelectFilesNavigationService(serviceProvider)),
                () => CreateNavigationBarViewModel(serviceProvider));
        }

        private INavigationService CreateSelectFilesNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SelectFilesViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => new SelectFilesViewModel(serviceProvider.GetRequiredService<FilesStore>(),
                    CreateDataEntryNavigationService(serviceProvider)),
                () => CreateNavigationBarViewModel(serviceProvider));
        }

        private INavigationService CreateDataEntryNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<DataEntryViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => new DataEntryViewModel(serviceProvider.GetRequiredService<FilesStore>(),
                    CreateHomeNavigationService(serviceProvider)),
                () => CreateNavigationBarViewModel(serviceProvider));
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                CreateSelectFilesNavigationService(serviceProvider),
                CreateHomeNavigationService(serviceProvider),
                CreateDataEntryNavigationService(serviceProvider)
            );
        }
    }
}