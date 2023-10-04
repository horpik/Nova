using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Nova.Models;
using Nova.Stores;
using Word;

namespace Nova.Commands
{
    public class CreateFilesCommand : CommandBase
    {
        private readonly List<FileItem> _fileItems;
        private readonly List<TagData> _tagDataList;


        public CreateFilesCommand(FilesStore filesStore, TagDataStore tagDataStore)
        {
            _tagDataList = tagDataStore.TagDataEntry;

            _fileItems = filesStore.FileItems;
        }

        public override void Execute(object parameter)
        {
            WordHelper wordHelper = new WordHelper();
            if (_fileItems != null)
            {
                var countCreatedDocs = wordHelper.CreateDocs(CreatePathsFilesList(), CreateDictionaryItems());
                MessageBox.Show($"Создано {countCreatedDocs} документов.");
                MakeAllFilesUnselected();
            }
        }

        private void MakeAllFilesUnselected()
        {
            foreach (var fileItem in _fileItems)
            {
                fileItem.IsSelected = false;
            }
        }

        private List<string> CreatePathsFilesList() =>
            (from fileItem in _fileItems
                where fileItem.IsSelected
                select fileItem.FilePath + "\\" + fileItem.FileName)
            .ToList();


        private Dictionary<string, string> CreateDictionaryItems()
        {
            return _tagDataList.ToDictionary(tagData => tagData.Tag, tagData => tagData.TagValue);
        }
    }
}