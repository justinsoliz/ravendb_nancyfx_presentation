using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IDocumentStore documentStore = new DocumentStore() {
                Url = "http://localhost:8080"
            }.Initialize())
            {
                documentStore.DatabaseCommands.EnsureDatabaseExists("Customers");

                using (IDocumentSession session = documentStore.OpenSession("Customers"))
                {
                    var customers = new List<Customer>() {
                        new Customer{ Name = "John", Homestate = "TN"},
                        new Customer{ Name = "Bob", Homestate = "TX"},
                        new Customer{Name = "Mark", Homestate = "CA"}
                    };

                    foreach (var customer in customers)
                        session.Store(customer);

                    session.SaveChanges();
                }
            }
        }
    }
}
