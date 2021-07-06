using AkkaDotNetPractice.Repository.Interface;
using System;

namespace AkkaDotNetPractice.Repository.Implementation
{
    class EmailNotification : IEmailNotification
    {
        public void sendMessage(string Message)
        {
            Console.WriteLine($"Sending email with message: {Message}");
        }
    }
}
