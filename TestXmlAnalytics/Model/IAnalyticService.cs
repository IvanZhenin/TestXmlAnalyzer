namespace TestXmlAnalytics.Model
{
	public interface IAnalyticService
	{
		long GetElementCount();
		List<string> GetElementNames();
		List<string> GetAttributeNames();
		Dictionary<string, long> GetAttributeSum();
	}
}