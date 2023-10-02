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

        public List<FileItem> FileItems { get; private set; }

        public SelectFilesViewModel(NavigationStore navigationStore)
        {
            GenerateFiles();
            SelectAllFilesCommand = new SelectAllFilesCommand(this,
                new NavigationService<DataEntryViewModel>(navigationStore,
                    () => new DataEntryViewModel(navigationStore)));
        }

        private void GenerateFiles()
        {
            FileItems = new List<FileItem>();
            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);

            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                FileItems.Add(new FileItem(file.Name, file.DirectoryName));
            }
        }
    }
}