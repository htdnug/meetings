using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ClassLibraryCS.Entities
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MailingAddress
    {
        [XmlAttribute]
        public string Label { get; set; }

        [XmlAttribute]
        public string StreetLine01 { get; set; }

        [XmlAttribute]
        public string StreetLine02 { get; set; }

        [XmlAttribute]
        public string City { get; set; }

        [XmlAttribute]
        public string State { get; set; }

        [XmlAttribute]
        public string Zip { get; set; }
    }
}
