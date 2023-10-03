using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private const string DirectoryPath = @"D:\\Dev\\Projects\\C#\\Nova\\Nova\\Src\\ViewModels";
        public ICommand NavigateSelectFilesCommand { get; }
        private int _countSelectedFiles;

        public int CountSelectedFiles
        {
            get => _countSelectedFiles;
            set
            {
                _countSelectedFiles = value;
                OnPropertyChanged(nameof(CountSelectedFiles));
            }
        }


        public HomeViewModel(FilesStore filesStore, INavigationService navigationService)
        {
            List<FileItem> fileItems;
            if (filesStore.FileItems == null)
            {
                fileItems = GenerateFilesList();

                filesStore.FileItems = fileItems;
            }
            else
            {
                fileItems = new List<FileItem>(filesStore.FileItems);
            }

            CountSelectedFiles = GetSelectedFilesCount(fileItems);
            NavigateSelectFilesCommand = new NavigateCommand<SelectFilesViewModel>(navigationService);
        }

        private int GetSelectedFilesCount(List<FileItem> fileItems) => fileItems.Count(file => file.IsSelected);


        private List<FileItem> GenerateFilesList()
        {
            var directoryInfo = new DirectoryInfo(DirectoryPath);

            var files = directoryInfo.GetFiles();

            var fileItems = new List<FileItem>();

            foreach (var file in files)
            {
                fileItems.Add(new FileItem(file.Name, file.DirectoryName));
            }

            return fileItems;
        }
    }
}