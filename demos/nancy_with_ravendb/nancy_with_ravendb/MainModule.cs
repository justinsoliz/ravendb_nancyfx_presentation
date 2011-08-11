using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace nancy_with_ravendb
{
    public class MainModule : BaseModule
    {
        public MainModule()
        {
            Get["/"] = _ => {

                var customers = DocumentSession.Query<Customer>()
                    .ToList();

                return View["Customers", customers];
            };
        }
    }
}