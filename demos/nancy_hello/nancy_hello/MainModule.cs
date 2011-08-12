using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace nancy_hello
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x => "nancy says hello!";

            Get["/razor-view"] = x => {
                return View["test", new { Name = "Justin" }];
            };
        }
    }

    public class PublicModule : NancyModule
    {
        public PublicModule()
            : base("/public")
        {
            Get["/css/{file}"] = x => {
                return Response.AsCss("/public/css/" + (string)x.file);
            };
        }
    }
}