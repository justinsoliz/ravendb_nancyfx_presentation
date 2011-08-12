using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Raven.Client;
using Raven.Client.Document;

namespace raven_hello
{
    class Program
    {
        static void Main(string[] args)
        {


            using (IDocumentStore documentStore = new DocumentStore() {
                Url = "http://localhost:8080"
            }.Initialize())
            {

                using (IDocumentSession session = documentStore.OpenSession())
                {
                    var employees = session.Advanced.LuceneQuery<Employee>()
                        .Where("Name:Justin")
                        .FirstOrDefault();
                }
            }


        }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Friend { get; set; }
    }
}
