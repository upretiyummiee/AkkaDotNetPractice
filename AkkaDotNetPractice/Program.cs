using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using AkkaDotNetPractice.Repository.Implementation;
using AkkaDotNetPractice.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AkkaDotNetPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();
            services.AddSingleton<IEmailNotification, EmailNotification>();
            services.AddSingleton<NotificationActor>();
            var serviceprovider = services.BuildServiceProvider();

            var detail = new Detail 
            {
                FirstName = "Prabesh",
                LastName = "Upreti",
                PhoneNumber = 9827279897
            };

            using var actorSystem = ActorSystem.Create("MyActor");
            actorSystem.UseServiceProvider(serviceprovider);
            var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());
            actor.Tell("Hello there");
            _ = Console.ReadKey();
            actorSystem.Stop(actor);
        }
    }
}
