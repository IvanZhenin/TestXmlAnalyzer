using Microsoft.Win32;
using System.Xml.Linq;

namespace TestXmlAnalytics.Utilities
{
	public class XmlFileReader
	{
		public static string FileRead()
		{
			var openFileDialog = new OpenFileDialog
			{
				Title = "Выберите XML-файл",
				Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*"
			};

			return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : "";
		}
	}
}