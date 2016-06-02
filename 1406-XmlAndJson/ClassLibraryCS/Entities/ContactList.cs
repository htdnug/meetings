using System.Collections.Generic;
using System.Xml.Serialization;

namespace ClassLibraryCS.Entities
{
    [XmlRoot("Contacts")]
    public class ContactList
    {
        public ContactList()
        {
            this.Contacts = new List<Person>();
        }

        [XmlElement("Person")]
        public List<Person> Contacts { get; set; }
    }
}
