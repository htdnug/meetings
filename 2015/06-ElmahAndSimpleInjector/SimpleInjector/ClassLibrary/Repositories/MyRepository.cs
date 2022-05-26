using System.Collections.Generic;

namespace ClassLibrary.Repositories
{
    public class MyRepository : IMyRepository
    {
        private readonly List<MyObject> data; 

        public MyRepository()
        {
            this.data = new List<MyObject>();
            this.GenerateData();
        }

        public IEnumerable<MyObject> GetItems()
        {
            return this.data;
        }

        private void GenerateData()
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                int id = i + 1;

                var myObject = new MyObject
                {
                    Id = id,
                    Name = string.Concat("My Obect ", id)
                };
                this.data.Add(myObject);
            }
        }
    }
}
