using Assignment15.notification_service;
using Assignment15.subscriber;

ISubscriber subscriber1 = new User("subscriber1");
ISubscriber subscriber2 = new User("subscriber2");
ISubscriber subscriber3 = new User("subscriber3");
ISubscriber subscriber4 = new User("subscriber4");
ISubscriber subscriber5 = new User("subscriber5");

Console.WriteLine();

String book1 = "book1", book2 = "book2", book3 = "book3";

BookstoreOrderNotificationService bookstoreNotificationService = new();
bookstoreNotificationService.AddBookInStock(book1);

Console.WriteLine();

bookstoreNotificationService.PlaceOrder(subscriber1, book1);
bookstoreNotificationService.PlaceOrder(subscriber2, book2);
bookstoreNotificationService.PlaceOrder(subscriber3, book1);
bookstoreNotificationService.PlaceOrder(subscriber4, book3);
bookstoreNotificationService.PlaceOrder(subscriber5, book2);

Console.WriteLine();

bookstoreNotificationService.AddBookInStock(book2);

bookstoreNotificationService.RedeemOrder(subscriber2, book2);
bookstoreNotificationService.RedeemOrder(subscriber5, book2);

Console.WriteLine();

bookstoreNotificationService.AddBookInStock(book3);

bookstoreNotificationService.RemoveBookFromStock(book3);
