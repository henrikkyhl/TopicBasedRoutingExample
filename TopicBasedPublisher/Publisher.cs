using System;
using EasyNetQ;
using Messages;

namespace TopicBasedPublisher
{
    class Publisher
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                string topic = "";
                Console.WriteLine("Enter a topic: ");

                while ((topic = Console.ReadLine()) != "Quit")
                {
                    var message = new TextMessage { Text = topic };
                    bus.PubSub.Publish<TextMessage>(message, topic);
                    Console.WriteLine("Enter a new topic: ");
                }
            }
        }
    }
}
