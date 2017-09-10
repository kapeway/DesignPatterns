using System;

namespace PatternsTutorial.Behavioral.Command
{
    public class BuyTransaction : ITransaction
    {
        public void Execute()
        {
            Console.WriteLine($"Buying :: {this.Value}");
        }

        public string Value { get; set; }
    }
}