using EasyNetQ;
using Messages;

string connectionStr =
    "host=hare.rmq.cloudamqp.com;virtualHost=npaprqop;username=npaprqop;password=<type your password here>";

Console.WriteLine("Enter subscriber id:");
string id = Console.ReadLine();
Console.WriteLine("Enter a topic: ");
string topic = Console.ReadLine();

using (var bus = RabbitHutch.CreateBus(connectionStr))
{
    bus.PubSub.Subscribe<TextMessage>("subscriber" + id, HandleTextMessage, 
                                x => x.WithTopic(topic));
    Console.WriteLine("Listening for messages.");
    Console.ReadLine();
}


void HandleTextMessage(TextMessage textMessage)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Got message: " + textMessage.Text);
    Console.ResetColor();
}
