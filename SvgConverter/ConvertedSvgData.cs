using System.IO;
using System.Windows;

namespace SvgConverter
{
    public class ConvertedSvgData
    {
        private string _filepath;
        private string _xaml;
        private string _svg;
        private string _objectName;
        private DependencyObject _convertedObj;

        public string Filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }

        public string Xaml
        {
            get
            {
                if (_xaml == null)
                {
                    DependencyObject convertedObj = ConvertedObj;
                    XamlWriteOptions options = new XamlWriteOptions()
                    {
                        Name = null,
                        IncludeNamespaces = true,
                        IncludeXmlDeclaration = true,
                    };
                    _xaml = ConverterLogic.SvgObjectToXaml(convertedObj, false, options);
                }
                return _xaml;
            }
            set { _xaml = value; }
        }

        public string Svg
        {
            get { return _svg ?? (_svg = File.ReadAllText(_filepath)); }
            set { _svg = value; }
        }

        public DependencyObject ConvertedObj
        {
            get
            {
                if (_convertedObj == null)
                {
                    ResourceDictionary resources = new ResourceDictionary();
                    _convertedObj = ConverterLogic.ConvertSvgToObject(_filepath, ResultMode.DrawingImage, null, out _objectName, new ResKeyInfo(), resources) as DependencyObject;
                }
                return _convertedObj;
            }
            set { _convertedObj = value; }
        }
    }
}
