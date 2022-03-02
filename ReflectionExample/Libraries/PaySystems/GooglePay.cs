using System;
using System.Collections.Generic;

namespace ReflectionExample
{
    public class GooglePay : IPay
    {
        public string CardHolder { get; private set; }
        public List<string> Cards { get; private set; }

        public GooglePay(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            CardHolder = name;
            Cards = new List<string>() { "1111 2222 3333 4444" };
        }

        public void AddCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) throw new ArgumentNullException(nameof(cardNumber));

            Cards.Add(cardNumber);
        }

        private void DeleteCard(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber)) throw new ArgumentNullException(nameof(cardNumber));

            if (Cards.Contains(cardNumber))
            {
                Cards.Remove(cardNumber);
            }
        }
    }
}
