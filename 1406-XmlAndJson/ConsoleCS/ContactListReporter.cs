using System;
using ClassLibraryCS.Entities;

namespace ConsoleCS
{
    internal class ContactListReporter
    {
        public void Report(ContactList contactList)
        {
            foreach (var person in contactList.Contacts)
            {
                this.DisplayPerson(person);
            }
        }

        private void DisplayPerson(Person person)
        {
            Console.WriteLine("First Name: " + person.FirstName);

            if (!string.IsNullOrEmpty(person.MiddleName))
            {
                Console.WriteLine("Middle Name: " + person.MiddleName);
            }

            Console.WriteLine("Last Name: " + person.LastName);

            if (person.Birthday.HasValue)
            {
                Console.WriteLine("Birthday: " + person.Birthday.Value.ToShortDateString());    
            }

            if (person.PhoneNumbers.Count > 0)
            {
                Console.WriteLine("Phone Numbers");
            }

            foreach (var phoneNumber in person.PhoneNumbers)
            {
                Console.WriteLine("  " + phoneNumber.Label + ": " + phoneNumber.Number);
            }

            if (person.EmailAddresses.Count > 0)
            {
                Console.WriteLine("Email Addresses");
            }

            foreach (var emailAddress in person.EmailAddresses)
            {
                Console.WriteLine("  " + emailAddress.Label + ": " + emailAddress.Email);
            }

            if (person.MailingAddresses.Count > 0)
            {
                Console.WriteLine("Mail Addresses");
            }

            foreach (var mailingAddress in person.MailingAddresses)
            {
                Console.WriteLine(" " + mailingAddress.Label + " Mailing Address");
                Console.WriteLine("    Address 01:" + mailingAddress.StreetLine01);

                if (!string.IsNullOrEmpty(mailingAddress.StreetLine02))
                {
                    Console.WriteLine("    Address 02:" + mailingAddress.StreetLine02);
                }

                Console.WriteLine("    City:" + mailingAddress.City);
                Console.WriteLine("    State:" + mailingAddress.State);
                Console.WriteLine("    Zip Code:" + mailingAddress.Zip);
            }
        }
    }
}
