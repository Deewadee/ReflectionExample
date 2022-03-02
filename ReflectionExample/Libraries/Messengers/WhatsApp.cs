using System;

namespace ReflectionExample
{
    public class WhatsApp : IMessenger
    {
        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

            Console.WriteLine(message);
        }

        public void SetStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) throw new ArgumentNullException(nameof(status));

            Console.WriteLine(status);
        }
    }
}
