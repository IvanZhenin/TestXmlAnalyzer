using System.Collections.Generic;

namespace TestXmlAnalytics.Model
{
    public abstract class FileService<T> : IAnalyticService
	{
	    protected T? FileContent;
	    public abstract string GetFile(string path);
	    public abstract long GetElementCount();
		public abstract List<string> GetElementNames();
		public abstract List<string> GetAttributeNames();
	    public abstract Dictionary<string, long> GetAttributeSum();
	}
}