using Akka.Actor;
using System;

namespace AkkaDotNetPractice
{
    class ChildNotificationActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            var m = message as Detail;

            Console.WriteLine($"Messaged recieved:");
            Console.WriteLine("Processing message from Child Actor");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"First Name: {m.FirstName}");
            Console.WriteLine($"Last Name: {m.LastName}");
            Console.WriteLine($"Phone Number: {m.PhoneNumber}");
            Console.WriteLine();
        }

        protected override void PreStart()
        {
            Console.WriteLine("Child Actor Started.");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("Child Actor stopped.");
            base.PostStop();
        }
    }
}
