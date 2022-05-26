using ClassLibraryCS;
using ClassLibraryCS.Json;

namespace ConsoleCS
{
    internal class JsonSerializationExample : SerializationExampleBase
    {
        public JsonSerializationExample(string filePath)
            : base(filePath)
        {
        }

        protected override IFileRepository Repository
        {
            get { return new JsonFileRepository(this.FullFilePath); }
        }
    }
}
