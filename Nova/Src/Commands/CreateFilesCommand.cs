using System.Collections.Generic;
using System.Linq;
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
                wordHelper.CreateDocs(CreatePathsFilesList(), CreateDictionaryItems());
            }
        }

        private List<string> CreatePathsFilesList() =>
            (from fileItem in _fileItems
                where fileItem.IsSelected
                select fileItem.FilePath + "\\" + fileItem.FileName)
            .ToList();


        private Dictionary<string, string> CreateDictionaryItems()
        {
            var dictionaryItems = new Dictionary<string, string>();
            foreach (var tagData in _tagDataList)
            {
                dictionaryItems.Add(tagData.Tag, tagData.TagValue);
            }

            return dictionaryItems;
        }
    }
}