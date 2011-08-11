using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gate;
using Nancy.Hosting.Owin;

namespace nancy_hosted_with_kayak
{
    public static class Extensions
    {
        public static IAppBuilder RunNancy(this IAppBuilder builder)
        {
            return builder.Run(Delegates.ToDelegate(new NancyOwinHost().ProcessRequest));
        }
    }
}
