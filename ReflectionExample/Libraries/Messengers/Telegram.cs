using System;

namespace ReflectionExample
{
    public class Telegram : IMessenger
    {
        private int _countUnreadMessages = 5;
        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            Console.WriteLine(message);
        }

        public void CreateCommunity()
        {
            Console.WriteLine("Community created");
        }

        public int GetMessagesCount()
        {
            return _countUnreadMessages;
        }
    }
}
