using System;

namespace IntroToLinq.ConsoleApplication
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ZipCode { get; set; }

        public DateTime DateLastPurchased { get; set; }

        public string FullName 
        { 
           get { return string.Concat(this.FirstName, " ", this.LastName).Trim(); }
        }

        public string SortableName 
        { 
           get { return string.Concat(this.LastName, ", ", this.FirstName); }
        }

        public override string ToString()
        {
            string[] parts = 
                { 
                    "Id: ",
                    this.Id.ToString(),
                    " | First Name: ", 
                    this.FirstName, 
                    " | Last Name: ", 
                    this.LastName, 
                    " | Zip Code: ",
                    this.ZipCode,
                    " | Last Purchase: ",
                    this.DateLastPurchased.ToShortDateString()
                };

            return string.Concat(parts);
        }
    }
}
