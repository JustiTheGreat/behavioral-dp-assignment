using Assignment15.subscriber;

namespace Assignment15.notification_service
{
    public class BookstoreOrderNotificationService : IOrderNotificationService
    {
        private readonly List<string> _booksInStock = [];
        private readonly List<KeyValuePair<ISubscriber, string>> _bookOrders = [];

        public void AddBookInStock(string bookName)
        {
            if (_booksInStock.Contains(bookName))
            {
                Console.WriteLine("Trying to add an already existing book in our stock!");
                return;
            }

            _booksInStock.Add(bookName);

            Console.WriteLine($"We added book {bookName} in our stock!");

            List<ISubscriber> subscribersToNotify = _bookOrders
                .Where(order => order.Value.Equals(bookName))
                .Select(order => order.Key)
                .ToList();

            NotifySubscribers(subscribersToNotify, "Your book has arrived!");
        }

        public void RemoveBookFromStock(string bookName)
        {
            if (_booksInStock.Contains(bookName))
            {
                Console.WriteLine("Trying to remove a book not present in our stock!");
                return;
            }

            _booksInStock.Remove(bookName);

            Console.WriteLine($"We removed book {bookName} from our stock!");

            List<ISubscriber> subscribersToNotify = _bookOrders
                .Where(order => order.Value.Equals(bookName))
                .Select(order => order.Key)
                .ToList();

            NotifySubscribers(subscribersToNotify, $"The stock for book {bookName} has emptied!");
        }

        public void PlaceOrder(ISubscriber subscriber, string bookName)
        {
            _bookOrders.Add(new KeyValuePair<ISubscriber, string>(subscriber, bookName));

            NotifySubscribers([subscriber], $"You placed an order to {nameof(BookstoreOrderNotificationService)} for {bookName}!");

            if (_booksInStock.Contains(bookName))
                NotifySubscribers([subscriber], $"We have your book!");
        }

        public void CancelOrder(ISubscriber subscriber, string bookName)
        {
            KeyValuePair<ISubscriber, string> orderToCancel = _bookOrders
                .FirstOrDefault(order => order.Key.Equals(subscriber) && order.Value.Equals(bookName));

            if (orderToCancel.Equals(default(KeyValuePair<ISubscriber, string>)))
            {
                Console.WriteLine("Trying to cancel an inexistent order!");
                return;
            }

            _bookOrders.Remove(orderToCancel);

            NotifySubscribers([subscriber], $"You canceled an order to {nameof(BookstoreOrderNotificationService)} for {bookName}!");
        }

        public void RedeemOrder(ISubscriber subscriber, string bookName)
        {
            KeyValuePair<ISubscriber, string> orderToRedeem = _bookOrders
                .FirstOrDefault(order => order.Key.Equals(subscriber) && order.Value.Equals(bookName));

            if (orderToRedeem.Equals(default(KeyValuePair<ISubscriber, string>)))
            {
                Console.WriteLine("Trying to redeem an inexistent order!");
                return;
            }

            _bookOrders.Remove(orderToRedeem);

            NotifySubscribers([subscriber], $"You redeemed an order to {nameof(BookstoreOrderNotificationService)} for {bookName}!");
        }

        public void NotifySubscribers(List<ISubscriber> subscribers, string message)
        {
            subscribers.ForEach(subscriber => subscriber.Notify(message));
        }
    }
}
