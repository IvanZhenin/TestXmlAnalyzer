namespace TestXmlAnalytics.Model
{
    public class FileAnalyzeModel
    {
        public long ElementCount { get; set; }
        public IEnumerable<string> ElementNames { get; set; } = [];
        public Dictionary<string, long> AttributeSum { get; set; } = [];
    }
}