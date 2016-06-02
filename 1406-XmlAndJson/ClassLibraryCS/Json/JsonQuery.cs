using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibraryCS.Json
{
    public class JsonQuery
    {
        private readonly string path;

        public JsonQuery(string pathToUse)
        {
            this.path = pathToUse;
        }

        public IEnumerable<string> GetPersonDetails()
        {
            JObject jsonObject = this.GetJsonObject();
            var firstName = (string)jsonObject.SelectToken("Contacts[1].FirstName");
            var lastName = (string)jsonObject.SelectToken("Contacts[1].LastName");
            var birthday = (DateTime)jsonObject.SelectToken("Contacts[1].Birthday");

            return new List<string>
            {
                firstName, 
                lastName,
                birthday.ToShortDateString()
            };
        }

        public IEnumerable<string> GetPersonEmails()
        {
            JObject jsonObject = this.GetJsonObject();

            var emailAddresses =
                from jo in jsonObject.SelectToken("Contacts[1].EmailAddresses")
                select new
                {
                    Label = (string)jo.SelectToken("Label"),
                    Email = (string)jo.SelectToken("Email")
                };

            return emailAddresses
                .Select(address => address.Label + " Email: " + address.Email)
                .ToList();
        }

        private JObject GetJsonObject()
        {
            if (!File.Exists(this.path))
            {
                return null;
            }

            using (StreamReader reader = File.OpenText(this.path))
            {
                return (JObject)JToken.ReadFrom(new JsonTextReader(reader));
            }
        }
    }
}
