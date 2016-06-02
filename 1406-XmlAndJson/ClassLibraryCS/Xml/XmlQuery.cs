using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ClassLibraryCS.Xml
{
    public class XmlQuery
    {
        private readonly string path;

        public XmlQuery(string pathToUse)
        {
            this.path = pathToUse;
        }

        public IEnumerable<string> GetPersonDetails()
        {
            XElement root = this.LoadFromFile();
            XElement element = root.Elements("Person").Skip(1).First();

            string firstName = (string)element.Attribute("FirstName");
            string lastName = (string)element.Attribute("LastName");
            DateTime birthday = (DateTime)element.Element("Birthday");

            return new List<string>
            {
                firstName, 
                lastName,
                birthday.ToShortDateString()
            };
        }

        public IEnumerable<string> GetPersonEmails()
        {
            XElement root = this.LoadFromFile();
            XElement personElement = root.Elements("Person").Skip(1).First();
            XElement emailsElement = personElement.Elements("EmailAddresses").First();

            var emailAddresses =
                from e in emailsElement.Elements("EmailAddress")
                select new
                {
                    Label = (string)e.Attribute("Label"),
                    Email = (string)e.Attribute("Email")
                };

            return emailAddresses
                .Select(x => x.Label + " Email: " + x.Email)
                .ToList();
        }

        private XElement LoadFromFile()
        {
            return XElement.Load(this.path);
        }
    }
}
