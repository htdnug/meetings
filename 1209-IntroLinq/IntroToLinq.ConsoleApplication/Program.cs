using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroToLinq.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                SumFluentSyntax();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }

        #region Select Examples

        private static void SimpleSelectSqlSyntax()
        {
            IEnumerable<int> numbers = DataGenerator.GetNumbersList();

            var results = from n in numbers 
                          select (n + 5);
            DisplayData(results);
        }

        private static void SimpleSelectFluentSyntax()
        {
            IEnumerable<int> numbers = DataGenerator.GetNumbersList();

            // NOTES: Equivalent Code
            //var results = new List<int>();
            //foreach (int number in numbers)
            //{
            //    results.Add(number + 5);
            //}

            var results = numbers.Select(n => n + 5);
            DisplayData(results);
        }

        private static void ObjectSelectSqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = from c in customers
                          select c;
            DisplayData(results);
        }

        private static void AnonTypeSelectSqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();

            var results = from c in customers 
                          select new { c.FirstName, c.LastName };

            foreach (var result in results)
            {
                Console.WriteLine(string.Concat(result.FirstName, " ", result.LastName));
            }
        }

        private static void AnonTypeSelectFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();

            var results = customers.Select(c => new { c.FirstName, c.LastName });

            foreach (var result in results)
            {
                Console.WriteLine(string.Concat(result.FirstName, " ", result.LastName));
            }
        }

        #endregion

        #region Where Examples

        private static void SimpleWhereSqlSyntax()
        {
            IEnumerable<int> numbers = DataGenerator.GetNumbersList();
            var results = from n in numbers 
                          where n < 5
                          select n;
            DisplayData(results);
        }

        private static void SimpleWhereFluentSyntax()
        {
            IEnumerable<int> numbers = DataGenerator.GetNumbersList();
            var results = numbers.Where(n => n < 5);
            DisplayData(results);
        }

        private static void ObjectWhereSqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = from c in customers 
                          where 
                            c.DateLastPurchased > new DateTime(2012, 6, 15)
                            && c.FirstName.Contains("e")
                          select c;
            DisplayData(results);
        }

        private static void ObjectWhereFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = customers.Where(c => c.DateLastPurchased > new DateTime(2012, 6, 15));
            DisplayData(results);
        }

        #endregion

        #region OrderBy Examples

        private static void SingleColumnOrderBySqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = from c in customers 
                          orderby c.LastName
                          select c;
            DisplayData(results);
        }

        private static void SingleColumnOrderByFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = customers.OrderBy(c => c.LastName);
            DisplayData(results);
        }

        private static void SingleColumnOrderByDescendingSqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = from c in customers 
                          orderby c.LastName descending 
                          select c;
            DisplayData(results);
        }

        private static void SingleColumnOrderByDescendingFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = customers
                .Where(c => c.DateLastPurchased > new DateTime(2012, 6, 15))
                .OrderByDescending(c => c.LastName);
            DisplayData(results);
        }

        private static void MultiColumnOrderBySqlSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = from c in customers orderby c.LastName , c.FirstName select c;
            DisplayData(results);
        }

        private static void MultiColumnOrderByFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var results = customers.OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
            DisplayData(results);
        }

        #endregion

        #region Element Operator Examples

        private static void FirstOrDefaultSqlSyntax()
        {
            // First() or FirstOrDefault()
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var result = (from c in customers 
                          where c.Id == 2 
                          select c).FirstOrDefault();
            Console.WriteLine(result.ToString());
        }

        private static void FirstOrDefaultFluentSyntax()
        {
            // First() or FirstOrDefault()
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var result = customers.FirstOrDefault(c => c.Id == 2);
            Console.WriteLine(result.ToString());
        }

        private static void SingleOrDefaultSqlSyntax()
        {
            // Single() or SingleOrDefault()
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var result = (from c in customers
                          where c.Id == 2
                          select c).SingleOrDefault();
            Console.WriteLine(result.ToString());
        }

        private static void SingleOrDefaultFluentSyntax()
        {
            // Single() or SingleOrDefault()
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var result = customers.SingleOrDefault(c => c.Id == 2);
            Console.WriteLine(result.ToString());
        }

        #endregion

        #region Any Examples

        private static void AnyFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            bool results = customers.Any();
        }

        private static void AnyConditionsFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            bool results = customers.Any(c => c.ZipCode == "63101" && c.LastName.Contains("e"));
        }

        #endregion

        #region Aggregate Functions

        private static void CountFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var count = customers.Count();
            Console.WriteLine(count);
        }

        private static void CountConditionalFluentSyntax()
        {
            IEnumerable<Customer> customers = DataGenerator.GetCustomerList();
            var count = customers.Count(c => c.LastName.Contains("e"));
            Console.WriteLine(count);
        }

        private static void SumFluentSyntax()
        {
            IEnumerable<Product> products = DataGenerator.GetProductList();
            var sum = products.Sum(p => p.UnitsInStock);
            Console.WriteLine(sum);
        }

        #endregion

        #region Private Helper Functions

        private static void DisplayData(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        private static void DisplayData(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        private static void DisplayData(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        #endregion
    }
}
