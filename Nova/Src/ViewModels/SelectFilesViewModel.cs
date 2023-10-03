using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class SelectFilesViewModel : ViewModelBase
    {
        private const string DirectoryPath = @"D:\\Dev\\Projects\\C#\\Nova\\Nova\\Src\\ViewModels";

        public ICommand SelectAllFilesCommand { get; }

        public List<FileItem> FileItems { get; }

        public SelectFilesViewModel(FilesStore filesStore, INavigationService navigationService)
        {
            if (filesStore.FileItems == null)
            {
                FileItems = new List<FileItem>();
                GenerateFilesList();
                filesStore.FileItems = FileItems;
            }
            else
            {
                FileItems = new List<FileItem>(filesStore.FileItems);
            }

            SelectAllFilesCommand = new SelectAllFilesCommand(filesStore, navigationService);
        }

        private void GenerateFilesList()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);

            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                FileItems.Add(new FileItem(file.Name, file.DirectoryName));
            }
        }
    }
}