namespace TestXmlAnalytics.Model
{
    public class FileAnalyzeModel
    {
        public int ElementCount { get; set; }
        public IEnumerable<string> ElementNames { get; set; } = [];
        public Dictionary<string, long> AttributeSum { get; set; } = [];
    }
}