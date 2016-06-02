using System.Collections.Generic;

namespace ClassLibrary.Services
{
    public interface IMyService
    {
        IEnumerable<MyObject> GetItems();
    }
}
