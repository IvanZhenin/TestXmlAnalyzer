using System.Windows;
using System.Xml.Linq;

namespace TestXmlAnalytics.Model
{
	public class XmlFileService : FileService<XDocument>
	{
		protected XDocument? FileContent;

		public override string GetFile(string path)
		{
			if (path == "")
				return "";

			try
			{
				FileContent = XDocument.Load(path);
				return path;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
				FileContent = null;
				return "";
			}
		}

		public override long GetElementCount()
		{
			return FileContent != null ? FileContent.Descendants().Count() : 0;
		}

		public override List<string> GetElementNames()
		{
			return FileContent != null ? FileContent.Descendants().Select(e => e.Name.LocalName).Distinct().ToList() : [];
		}

		public override List<string> GetAttributeNames()
		{
			return FileContent != null ? FileContent.Descendants()
					.SelectMany(e => e.Attributes().Select(a => a.Name.LocalName))
					.Distinct()
					.ToList() : [];
		}

		public override Dictionary<string, long> GetAttributeSum()
		{
			if (FileContent == null)
				return [];

			var attributeNames = GetAttributeNames();

			var result = new Dictionary<string, long>();

			foreach (var attributeName in attributeNames)
			{
				var attributeCount = FileContent.Descendants()
					.SelectMany(e => e.Attributes())
					.Where(a => a.Name.LocalName == attributeName)
					.Count();

				result.Add(attributeName, attributeCount);
			}

			return result;
		}
	}
}