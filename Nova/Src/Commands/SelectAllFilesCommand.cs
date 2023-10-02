using System.Windows;
using Nova.Services;
using Nova.Stores;
using Nova.ViewModels;

namespace Nova.Commands
{
    public class SelectAllFilesCommand : CommandBase
    {
        private readonly SelectFilesViewModel _selectFilesModel;
        private readonly NavigationService<DataEntryViewModel> _navigationService;

        public SelectAllFilesCommand(SelectFilesViewModel selectFilesModel,
            NavigationService<DataEntryViewModel> navigationService)
        {
            _selectFilesModel = selectFilesModel;
            _navigationService = navigationService;
        }


        public override void Execute(object parameter)
        {
            // TODO
            var a = 1;
            foreach (var fileItem in _selectFilesModel.FileItems)
            {
                fileItem.IsSelected = true;
            }
            /*MessageBox.Show("Ok!");*/
            /*_navigationService.Navigate();*/
        }
    }
}