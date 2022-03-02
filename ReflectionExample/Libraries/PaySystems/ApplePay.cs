using System;

namespace ReflectionExample
{
    public class ApplePay : IPay
    {
        public int Cards { get; private set; }
        public void AddCard()
        {
            Cards += 1;
            Console.WriteLine("Your card added");
        }

        public void DeleteCard(string cardNumber)
        {
            Console.WriteLine($"Card '{cardNumber}' removed");
        }

        public void Pay()
        {
            Console.WriteLine("Payment was successfull");
        }
    }
}
