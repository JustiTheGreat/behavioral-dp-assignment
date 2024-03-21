namespace Assignment15.subscriber
{
    public class User(string name) : ISubscriber
    {
        public string Name { get; set; } = name;

        public void Notify(string message)
        {
            Console.WriteLine($"{Name}: {message}");
        }
    }
}
