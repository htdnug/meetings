using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ClassLibraryCS.Entities
{
    [JsonObject(MemberSerialization.OptOut)]
    public class EmailAddress
    {
        [XmlAttribute]
        public string Email { get; set; }

        [XmlAttribute]
        public string Label { get; set; }
    }
}
