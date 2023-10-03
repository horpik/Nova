using System.Collections.Generic;
using Nova.Models;
using Nova.Stores;
namespace Nova.Commands
{
    public class CreateFilesCommand : CommandBase
    {
        private readonly List<FileItem> _fileItems;

        public CreateFilesCommand(FilesStore filesStore)
        {
            _fileItems = filesStore.FileItems;
        }

        public override void Execute(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}