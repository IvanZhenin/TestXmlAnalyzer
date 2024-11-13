using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using TestXmlAnalytics.Model;
using TestXmlAnalytics.Utilities;

namespace TestXmlAnalytics.ViewModel
{
    public class AnalyticSerivceViewModel : BaseViewModel
	{
		private readonly FileService<XDocument> _fileService;

		public AnalyticSerivceViewModel()
		{
			_fileService = new XmlFileService();
		}

		private string _filePath;
		public string FilePath
		{
			get => _filePath;
			set
			{
				if (FilePath != value)
				{
					_filePath = value;
					_fileService.GetFile(value);
					OnPropertyChanged(nameof(ElementCount));
					OnPropertyChanged(nameof(ElementNames));
					OnPropertyChanged(nameof(AttributeSum));
				}
			}
		}

		public long ElementCount
		{
			get
			{
				return _fileService.GetElementCount();
			}
		}

		public List<string> ElementNames
		{
			get
			{
				return _fileService.GetElementNames();
			}
		}

		public Dictionary<string, long> AttributeSum
		{
			get
			{
				return _fileService.GetAttributeSum();
			}
		}

		public ICommand ChooseFilePath
		{
			get
			{
				return new RelayCommand((obj) =>
				{
					FilePath = XmlFileReader.FileRead();
				});
			}
		}
	}
}