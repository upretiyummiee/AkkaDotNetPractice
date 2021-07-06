using Akka.Actor;
using AkkaDotNetPractice.Repository.Interface;
using System;

namespace AkkaDotNetPractice
{
    class EmailNotificationActor : UntypedActor
    {
        private readonly IEmailNotification _notification;

        public EmailNotificationActor(IEmailNotification notification) 
        {
            _notification = notification;
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine();
            Console.WriteLine("Sending Email notification under same actor system.");
            _notification.sendMessage(message as string);
        }

        protected override void PreStart()
        {
            Console.WriteLine("Email Notification Actor Started.");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("Email Notification Actor stopped.");
            base.PostStop();
        }
    }
}
