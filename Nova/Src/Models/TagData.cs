namespace Nova.Models
{
    public class TagData
    {
        public string DescriptionTag { get; }
        public string Tag { get; }
        public string TagValue { get; set; }

        public TagData(string descriptionTag, string tag)
        {
            DescriptionTag = descriptionTag;
            Tag = tag;
            TagValue = "";
        }
    }
}