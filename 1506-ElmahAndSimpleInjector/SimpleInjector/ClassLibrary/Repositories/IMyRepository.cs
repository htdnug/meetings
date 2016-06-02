using System.Collections.Generic;

namespace ClassLibrary.Repositories
{
    public interface IMyRepository
    {
        IEnumerable<MyObject> GetItems();
    }
}
