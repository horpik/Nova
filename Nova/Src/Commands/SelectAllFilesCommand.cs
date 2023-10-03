using System.Collections.Generic;
using System.Windows;
using Nova.Models;
using Nova.Services;
using Nova.Stores;
using Nova.ViewModels;

namespace Nova.Commands
{
    public class SelectAllFilesCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly List<FileItem> _fileItems;

        public SelectAllFilesCommand(FilesStore filesStore,
            INavigationService navigationService)
        {
            _navigationService = navigationService;
            _fileItems = filesStore.FileItems;
        }


        public override void Execute(object parameter)
        {
            foreach (var fileItem in _fileItems)
            {
                fileItem.IsSelected = true;
            }

            MessageBox.Show("Ok!");
            _navigationService.Navigate();
        }
    }
}