using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nancy_with_ravendb
{
    public class MainModule : BaseModule 
    {
        public MainModule()
        {
            Get["/"] = _ => "Nancy is wired up with RavenDB";
        }
    }
}