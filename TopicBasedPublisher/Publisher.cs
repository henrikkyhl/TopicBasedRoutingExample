using EasyNetQ;
using Messages;

string connectionStr =
    "host=hare.rmq.cloudamqp.com;virtualHost=npaprqop;username=npaprqop;password=<type your password here>";

using (var bus = RabbitHutch.CreateBus(connectionStr))
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
