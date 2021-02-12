using System;
using EasyNetQ;
using Messages;

namespace TopicBasedSubscriber
{
    class Subscriber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter subscriber id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter a topic: ");
            string topic = Console.ReadLine();

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<TextMessage>("subscriber" + id, HandleTextMessage, 
                                           x => x.WithTopic(topic));
                Console.WriteLine("Listening for messages.");
                Console.ReadLine();
            }

        }

        static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: " + textMessage.Text);
            Console.ResetColor();
        }
    }
}
