using System;
using System.Collections.Generic;

namespace IntroToLinq.ConsoleApplication
{
    public static class DataGenerator
    {
        public static IEnumerable<int> GetNumbersList()
        {
            return new List<int> { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        }

        public static IEnumerable<Customer> GetCustomerList()
        {
            // fakenamegenerator.com
            return new List<Customer>
                {
                    new Customer
                        {
                            Id = 1,
                            FirstName = "Marcus", 
                            LastName = "Lewis", 
                            DateLastPurchased = new DateTime(2012, 03, 15), 
                            ZipCode = "46940"
                        },
                    new Customer
                        {
                            Id = 2,
                            FirstName = "Shirley", 
                            LastName = "Brewster", 
                            DateLastPurchased = new DateTime(2012, 07, 19),
                            ZipCode = "10007"
                        },
                    new Customer
                        {
                            Id = 3,
                            FirstName = "Fredrick", 
                            LastName = "Reynolds", 
                            DateLastPurchased = new DateTime(2012, 09, 12),
                            ZipCode = "63101"
                        },
                    new Customer
                        {
                            Id = 4,
                            FirstName = "Denise", 
                            LastName = "Johnson", 
                            DateLastPurchased = new DateTime(2012, 08, 26),
                            ZipCode = "95661"
                        }
                };
        }

        public static IEnumerable<Product> GetProductList()
        {
            // thank you thinkgeek!
            return new List<Product>
                {
                    new Product
                        {
                            Id = 1,
                            Price = 12.99m,
                            Title = "Samurai Sword Chopstick Set",
                            UnitsInStock = 81
                        },
                    new Product
                        {
                            Id = 2,
                            Price = 11.99m,
                            Title = "Silicone USB SATA 2.5 inch Drive Enclosure",
                            UnitsInStock = 64
                        },
                    new Product
                        {
                            Id = 3,
                            Price = 9.99m,
                            Title = "USB Flexlight",
                            UnitsInStock = 121
                        },
                    new Product
                        {
                            Id = 4,
                            Price = 29.99m,
                            Title = "Coffee Cup Power Inverter",
                            UnitsInStock = 49
                        }
                };
        }
    }
}
