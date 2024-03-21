namespace Assignment15.subscriber
{
    public interface ISubscriber
    {
        public string Name { get; }

        public void Notify(string message);
    }
}
