using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ClassLibraryCS.Entities
{
    [JsonObject(MemberSerialization.OptOut)]
    public class PhoneNumber
    {
        [XmlAttribute]
        public string Number { get; set; }

        [XmlAttribute]
        public string Label { get; set; }
    }
}
