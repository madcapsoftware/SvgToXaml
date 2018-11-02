using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SvgConverter
{
    public class XamlWriteOptions
    {
        public string Name { get; set; }
        public bool IncludeNamespaces { get; set; }
        public bool IncludeXmlDeclaration { get; set; }
    }
}
