using ClassLibraryCS;
using ClassLibraryCS.Xml;

namespace ConsoleCS
{
    internal class XmlSerializationExample : SerializationExampleBase
    {
        public XmlSerializationExample(string filePath)
            : base(filePath)
        {
        }

        protected override IFileRepository Repository
        {
            get { return new XmlFileRepository(this.FullFilePath); }
        }
    }
}
