using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ClassLibraryCS.Entities
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Person
    {
        public Person()
        {
            this.EmailAddresses = new List<EmailAddress>();
            this.PhoneNumbers = new List<PhoneNumber>();
            this.MailingAddresses = new List<MailingAddress>();
        }

        [XmlAttribute]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(this.FirstName)
                    && string.IsNullOrEmpty(this.LastName))
                {
                    return string.Empty;
                }

                if (string.IsNullOrEmpty(this.FirstName))
                {
                    return this.LastName;
                }

                return string.IsNullOrEmpty(this.LastName)
                    ? this.FirstName
                    : string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        [JsonIgnore]
        public string Label
        {
            get
            {
                if (string.IsNullOrEmpty(this.FirstName)
                    && string.IsNullOrEmpty(this.LastName))
                {
                    return string.Empty;
                }

                if (string.IsNullOrEmpty(this.FirstName))
                {
                    return this.LastName;
                }

                if (string.IsNullOrEmpty(this.MiddleName))
                {
                    return string.IsNullOrEmpty(this.LastName)
                        ? this.FirstName
                        : string.Format("{0}, {1}", this.LastName, this.FirstName);
                }

                return string.IsNullOrEmpty(this.LastName)
                    ? this.FirstName
                    : string.Format("{0}, {1} {2}", this.LastName, this.FirstName, this.MiddleName);
            }
        }

        [XmlAttribute]
        public string LastName { get; set; }

        [XmlAttribute]
        public string MiddleName { get; set; }

        public DateTime? Birthday { get; set; }

        public List<EmailAddress> EmailAddresses { get; set; }

        public List<PhoneNumber> PhoneNumbers { get; set; }

        public List<MailingAddress> MailingAddresses { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public int? Age
        {
            get
            {
                if (!this.Birthday.HasValue)
                {
                    return null;
                }

                DateTime now = DateTime.Today;
                int age = now.Year - this.Birthday.Value.Year;

                if (this.Birthday.Value > now.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Label))
            {
                return base.ToString();    
            }

            return this.Label;
        }
    }
}
