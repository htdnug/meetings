using System.Collections.Generic;
using ClassLibrary.Repositories;

namespace ClassLibrary.Services
{
    public class MyService : IMyService
    {
        private readonly IMyRepository repository;

        public MyService(IMyRepository repositoryToUse)
        {
            this.repository = repositoryToUse;
        }

        public IEnumerable<MyObject> GetItems()
        {
            return this.repository.GetItems();
        }
    }
}
