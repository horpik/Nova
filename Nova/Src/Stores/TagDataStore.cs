using System.Collections.Generic;
using Nova.Models;

namespace Nova.Stores
{
    public class TagDataStore
    {
        private List<TagData> _tagDataEntry;


        public List<TagData> TagDataEntry
        {
            get => _tagDataEntry;
            set => _tagDataEntry = value;
        }
    }
}