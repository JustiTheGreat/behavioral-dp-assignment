using Assignment15.subscriber;

namespace Assignment15.notification_service
{
    public interface IOrderNotificationService
    {
        void PlaceOrder(ISubscriber subscriber, string bookName);
        void CancelOrder(ISubscriber subscriber, string bookName);
        void RedeemOrder(ISubscriber subscriber, string bookName);
        void NotifySubscribers(List<ISubscriber> subscribers, string message);
    }
}
