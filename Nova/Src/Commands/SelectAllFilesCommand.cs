﻿using System.Collections.Generic;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

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

            _navigationService.Navigate();
        }
    }
}