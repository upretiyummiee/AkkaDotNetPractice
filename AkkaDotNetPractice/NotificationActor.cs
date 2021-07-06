using Akka.Actor;
using AkkaDotNetPractice.Repository.Interface;
using System;

namespace AkkaDotNetPractice
{
    class NotificationActor : UntypedActor
    {
        private readonly IEmailNotification _notification;

        public NotificationActor(IEmailNotification notification) 
        {
            _notification = notification;
        }

        protected override void OnReceive(object message)
        {
            var m = message as Detail;

            Console.WriteLine($"Messaged recieved:");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"First Name: {m.FirstName}");
            Console.WriteLine($"Last Name: {m.LastName}");
            Console.WriteLine($"Phone Number: {m.PhoneNumber}");

            //_notification.sendMessage(message?.ToString());
        }

        protected override void PreStart()
        {
            Console.WriteLine("Actor Started.");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("Actor stopped");
            base.PostStop();
        }
    }
}
