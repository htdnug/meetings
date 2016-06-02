using System;
using System.Collections.Generic;
using ClassLibraryCS.Entities;

namespace ClassLibraryCS
{
    public class PersonFactory
    {
        public Person MakeJohnDeaux()
        {
            return new Person
            {
                Birthday = new DateTime(1983, 6, 23),
                FirstName = "John",
                LastName = "Deaux",
                MailingAddresses = new List<MailingAddress>
                {
                    new MailingAddress
                    {
                        Label = "Work",
                        StreetLine01 = "321 Corporate Dr.",
                        City = "Houma",
                        State = "LA",
                        Zip = "54321"
                    }, 
                    new MailingAddress
                    {
                        Label = "Home",
                        StreetLine01 = "123 Some Rd.",
                        City = "Houma",
                        State = "LA",
                        Zip = "54321"
                    }
                },
                EmailAddresses = new List<EmailAddress>
                {
                    new EmailAddress {Label = "Personal", Email = "john@deaux.com"}, 
                    new EmailAddress {Label = "Work", Email = "jdeaux@work.com"}
                },
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber {Label = "Home", Number = "985-555-1234"}, 
                    new PhoneNumber { Label = "Work", Number = "985-555-4321" }, 
                    new PhoneNumber { Label = "Cell", Number = "985-555-5678" }
                }
            };
        }

        public Person MakeJaneDoe()
        {
            return new Person
            {
                Birthday = new DateTime(1983, 3, 9),
                FirstName = "Jane",
                LastName = "Doe",
                MailingAddresses = new List<MailingAddress>
                {
                    new MailingAddress
                    {
                        Label = "Work",
                        StreetLine01 = "789 Enterprise Dr.",
                        City = "Thibodaux",
                        State = "LA",
                        Zip = "12345"
                    }, 
                    new MailingAddress
                    {
                        Label = "Home",
                        StreetLine01 = "987 Main St.",
                        City = "Thibodaux",
                        State = "LA",
                        Zip = "12345"
                    }
                },
                EmailAddresses = new List<EmailAddress>
                {
                    new EmailAddress {Label = "Personal", Email = "jane@doe.com"}, 
                    new EmailAddress {Label = "Work", Email = "jdoe@work.com"}
                },
                PhoneNumbers = new List<PhoneNumber>
                {
                    new PhoneNumber {Label = "Home", Number = "985-555-8765"}, 
                    new PhoneNumber { Label = "Work", Number = "985-555-7890" }, 
                    new PhoneNumber { Label = "Cell", Number = "985-555-0987" }
                }
            };
        }
    }
}
