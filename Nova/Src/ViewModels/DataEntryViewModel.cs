using System.Collections.Generic;
using System.Windows.Input;
using Nova.Commands;
using Nova.Models;
using Nova.Services;
using Nova.Stores;

namespace Nova.ViewModels
{
    public class DataEntryViewModel : ViewModelBase
    {
        public string WelcomeMessage => "Welcome to my application.";

        public ICommand NavigateHomeCommand { get; }

        private readonly List<TagData> _tagDataList;

        public List<TagData> TagDataList => new List<TagData>(_tagDataList);

        public DataEntryViewModel(TagDataStore dataStore, INavigationService homeNavigationService)
        {
            _tagDataList = dataStore.TagDataEntry;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}