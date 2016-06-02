using System.IO;
using ClassLibraryCS.Entities;
using Newtonsoft.Json;

namespace ClassLibraryCS.Json
{
    public class JsonFileRepository : FileRepositoryBase, IFileRepository
    {
        public JsonFileRepository(string path)
            : base(path)
        {
        }

        public void Serialize(ContactList contactList)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            string json = JsonConvert.SerializeObject(contactList, settings);
            File.WriteAllText(this.Path, json);
        }

        public ContactList Deserialize()
        {
            if (File.Exists(this.Path))
            {
                string json = File.ReadAllText(this.Path);
                return JsonConvert.DeserializeObject<ContactList>(json);
            }

            return null;
        }
    }
}
