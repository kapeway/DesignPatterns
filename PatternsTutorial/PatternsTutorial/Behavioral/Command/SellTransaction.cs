using System;

namespace PatternsTutorial.Behavioral.Command
{
    public class SellTransaction : ITransaction
    {
        public void Execute()
        {
            Console.WriteLine($"Selling :: {this.Value}");
        }

        public string Value { get; set; }
    }
}