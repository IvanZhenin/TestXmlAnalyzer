using System.Xml.Linq;

namespace TestXmlAnalytics.AnalyticServices
{
    public class XmlAnalyticService : IAnalyticService
    {
        private readonly XDocument _xmlDocument;

        public XmlAnalyticService(string filePath)
        {
            _xmlDocument = XDocument.Load(filePath);
        }

        public long GetElementCount()
        {
            return _xmlDocument.Descendants().Count();
        }

        public IEnumerable<string> GetElementNames()
        {
            return _xmlDocument.Descendants().Select(e => e.Name.LocalName).Distinct();
        }

        public Dictionary<string, long> GetAttributeSum(string attributeName)
        {
			var elementCounts = _xmlDocument.Descendants()
				.GroupBy(e => e.Name.LocalName)
				.Select(g => new { Name = g.Key, Count = (long)g.Count() });

			return elementCounts.ToDictionary(ec => ec.Name, ec => ec.Count);
		}
    }
}
