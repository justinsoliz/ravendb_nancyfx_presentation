using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Raven.Client;

namespace nancy_with_ravendb
{
    public abstract class BaseModule : NancyModule
    {
        protected BaseModule() { }

        protected BaseModule(string modulePath)
            : base(modulePath) { }

        protected IDocumentSession DocumentSession
        {
            get { return Context.Items["RavenSession"] as IDocumentSession; }
        }
    }
}