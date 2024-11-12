namespace TestXmlAnalytics.AnalyticServices
{
    public interface IAnalyticService
    {
        long GetElementCount();
        IEnumerable<string> GetElementNames();
        Dictionary<string, long> GetAttributeSum(string attributeName);
    }
}