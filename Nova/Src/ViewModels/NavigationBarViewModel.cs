﻿using System.Windows.Input;
using Nova.Commands;
using Nova.Services;

namespace Nova.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateDataEntryCommand { get; }
        public ICommand NavigateSelectFilesCommand { get; }

        public NavigationBarViewModel(NavigationService<SelectFilesViewModel> selectFilesNavigationService,
            NavigationService<HomeViewModel> homeNavigationService,
            NavigationService<DataEntryViewModel> dataEntryNavigationService)
        {
            NavigateSelectFilesCommand = new NavigateCommand<SelectFilesViewModel>(selectFilesNavigationService);
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateDataEntryCommand = new NavigateCommand<DataEntryViewModel>(dataEntryNavigationService);
        }
    }
}