using ClassLibraryCS.Entities;

namespace ClassLibraryCS
{
    public interface IFileRepository
    {
        void Serialize(ContactList contactList);

        ContactList Deserialize();
    }
}
