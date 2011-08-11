using System;
using System.Diagnostics;
using System.Net;
using Gate.Kayak;
using Nancy;

namespace nancy_hosted_with_kayak
{
    class Program
    {
        static void Main(string[] args)
        {
            var ep = new IPEndPoint(IPAddress.Any, 8889);
            Console.WriteLine("Listening on " + ep);
            Console.WriteLine("Press CTRL+C to quit :-)");
            Process.Start("http://localhost:8889");
            KayakGate.Start(new SchedulerDelegate(), ep, Startup.Configuration);
        }
    }

    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = x => "Nancy hosted on a Kayak server";
        }
    }
}
