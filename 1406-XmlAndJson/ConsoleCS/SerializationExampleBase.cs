using ClassLibraryCS;
using ClassLibraryCS.Entities;

namespace ConsoleCS
{
    internal abstract class SerializationExampleBase
    {
        protected SerializationExampleBase(string fullFilePath)
        {
            this.FullFilePath = fullFilePath;
        }

        protected string FullFilePath { get; set; }

        protected abstract IFileRepository Repository { get; }

        public void RunSerializeExample()
        {
            var factory = new PersonFactory();

            var contactList = new ContactList();
            contactList.Contacts.Add(factory.MakeJohnDeaux());
            contactList.Contacts.Add(factory.MakeJaneDoe());

            this.Repository.Serialize(contactList);
        }

        public void RunDeserializeExample()
        {
            var contactList = this.Repository.Deserialize();

            var reporter = new ContactListReporter();
            reporter.Report(contactList);
        }
    }
}
