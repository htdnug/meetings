using System;
using System.Collections.Generic;
using ClassLibraryCS.Json;
using ClassLibraryCS.Xml;

namespace ConsoleCS
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                const string xmlFilePath = @"D:\temp\xml.txt";
                const string jsonFilePath = @"D:\temp\json.txt";

                //RunXmlSerializationExamples(xmlFilePath);
                //RunJsonSerializationExamples(jsonFilePath);

                //RunXmlQueryExamples(xmlFilePath);
                //RunJsonQueryExamples(jsonFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        private static void RunXmlSerializationExamples(string xmlFilePath)
        {
            var xmlSerialization = new XmlSerializationExample(xmlFilePath);
            xmlSerialization.RunSerializeExample();
            xmlSerialization.RunDeserializeExample();
        }

        private static void RunJsonSerializationExamples(string jsonFilePath)
        {
            var jsonSerialization = new JsonSerializationExample(jsonFilePath);
            jsonSerialization.RunSerializeExample();
            jsonSerialization.RunDeserializeExample();
        }

        private static void RunXmlQueryExamples(string xmlFilePath)
        {
            var query = new XmlQuery(xmlFilePath);

            var output = new List<string>();
            output.AddRange(query.GetPersonDetails());
            output.AddRange(query.GetPersonEmails());

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }

        private static void RunJsonQueryExamples(string jsonFilePath)
        {
            var query = new JsonQuery(jsonFilePath);

            var output = new List<string>();
            output.AddRange(query.GetPersonDetails());
            output.AddRange(query.GetPersonEmails());

            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }
    }
}
