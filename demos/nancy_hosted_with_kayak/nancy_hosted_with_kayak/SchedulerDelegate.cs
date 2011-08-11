using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kayak;

namespace nancy_hosted_with_kayak
{
    public class SchedulerDelegate : ISchedulerDelegate
    {
        public void OnException(IScheduler scheduler, Exception e)
        {
            // called whenever an exception occurs on Kayak's event loop.
            // this is good place for logging. here's a start:

            Console.WriteLine("Exception on scheduler");
            Console.Out.WriteStackTrace(e);
        }

        public void OnStop(IScheduler scheduler)
        {
            // called when Kayak's run loop is about to exit.
            // this is a good place for doing clean-up or other chores.

            Console.WriteLine("Scheduler is stopping.");
        }
    }
}
