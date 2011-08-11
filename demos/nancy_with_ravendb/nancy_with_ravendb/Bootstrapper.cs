using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Bootstrapper;

namespace nancy_with_ravendb
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override Nancy.Bootstrapper.NancyInternalConfiguration InternalConfiguration
        {
            get { return NancyInternalConfiguration.WithOverrides(x => x.NancyModuleBuilder = typeof(RavenModuleBuilder)); }
        }
    }
}