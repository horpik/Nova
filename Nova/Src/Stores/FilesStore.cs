using System.Collections.Generic;
using Nova.Models;

namespace Nova.Stores
{
    public class FilesStore
    {
        private List<FileItem> _fileItems;

        public List<FileItem> FileItems
        {
            get => _fileItems;
            set => _fileItems = value;
        }
    }
}