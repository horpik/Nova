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
        private readonly SelectFilesViewModel _selectFilesModel;
        private readonly ParameterNavigationService<List<FileItem>, DataEntryViewModel> _navigationService;
        private readonly List<FileItem> _fileItems;

        public SelectAllFilesCommand(SelectFilesViewModel selectFilesModel,
            ParameterNavigationService<List<FileItem>, DataEntryViewModel> navigationService)
        {
            _selectFilesModel = selectFilesModel;
            _navigationService = navigationService;
            _fileItems = _selectFilesModel.FileItems;
        }


        public override void Execute(object parameter)
        {
            foreach (var fileItem in _fileItems)
            {
                fileItem.IsSelected = true;
            }

            MessageBox.Show("Ok!");
            _navigationService.Navigate(_fileItems);
        }
    }
}