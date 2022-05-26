using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using ClassLibraryCS.Entities;

namespace ClassLibraryCS.Xml
{
    public class XmlFileRepository : FileRepositoryBase, IFileRepository
    {
        public XmlFileRepository(string path)
            : base(path)
        {
        }

        public void Serialize(ContactList contactList)
        {
            var serializer = new XmlSerializer(typeof(ContactList));

            using (var writer = new StreamWriter(this.Path))
            {
                serializer.Serialize(writer, contactList);
            }
        }

        public ContactList Deserialize()
        {
            var serializer = new XmlSerializer(typeof(ContactList));

            using (var fileStream = new FileStream(this.Path, FileMode.Open))
            {
                return serializer.Deserialize(fileStream) as ContactList;
            }
        }
    }
}
