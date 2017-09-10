using System;
using System.Collections.Generic;

namespace PatternsTutorial.Behavioral.Command
{
    public class Agent
    {
        public Agent()
        {
            _transactionStack=new Stack<ITransaction>();
        }

        private Stack<ITransaction> _transactionStack { get; set; }

        public void PlaceOrder(ITransaction transaction)
        {
            transaction.Execute();
            _transactionStack.Push(transaction);
        }

        public void RedoLastTransaction()
        {
            if (_transactionStack.Count > 0)
            {
                var lastTransaction = _transactionStack.Pop();
                lastTransaction.Execute();
            }
            else
            {
                Console.WriteLine("No more transactions to redo!");
            }
        }
    }
}