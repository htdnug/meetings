namespace IntroToLinq.ConsoleApplication
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int UnitsInStock { get; set; }

        public bool IsInStock 
        { 
            get { return this.UnitsInStock > 0; }
        }

        public override string ToString()
        {
                string[] parts = 
                { 
                    "Id: ",
                    this.Id.ToString(),
                    " | Title: ", 
                    this.Title, 
                    " | Price: ", 
                    this.Price.ToString(), 
                    " | Units In Stock: ",
                    this.UnitsInStock.ToString()
                };

            return string.Concat(parts);
        }
    }
}
