using Akka.Actor;
using Akka.DI.Core;
using AkkaDotNetPractice.Repository.Interface;
using System;

namespace AkkaDotNetPractice
{
    class NotificationActor : UntypedActor
    {
        private readonly IEmailNotification _notification;
        private readonly IActorRef _actor;

        public NotificationActor(IEmailNotification notification) 
        {
            _notification = notification;
            _actor = Context.ActorOf(Context.System.DI().Props<ChildNotificationActor>());
        }

        protected override void OnReceive(object message)
        {
            var m = message as Detail;

            Console.WriteLine($"Messaged recieved:");
            Console.WriteLine("Processing message from Parent Actor");
            Console.WriteLine("-----------------------");
            Console.WriteLine($"First Name: {m.FirstName}");
            Console.WriteLine($"Last Name: {m.LastName}");
            Console.WriteLine($"Phone Number: {m.PhoneNumber}");
            Console.WriteLine();

            _actor.Tell(message);

            _actor.GracefulStop(TimeSpan.Zero);
        }

        protected override void PreStart()
        {
            Console.WriteLine("Parent Actor Started.");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("Parent Actor stopped.");
            base.PostStop();
        }
    }
}
