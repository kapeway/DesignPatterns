using NUnit.Framework;
using PatternsTutorial.Behavioral.Command;

namespace PatternsTutorialTests.Behavioral
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Agent_TriesRedoTransaction_ShouldBeAbleToRedo()
        {
            var agent = new Agent();
            agent.PlaceOrder(new BuyTransaction {Value="HDFC 10 shares" });
            agent.PlaceOrder(new SellTransaction { Value = "HDFC 5 shares" });
            agent.RedoLastTransaction();
        }
        [Test]
        public void Agent_TriesRedoTransactionMoreThanExecuted_ShouldSayNoMoreTransactionToRedo()
        {
            var agent = new Agent();
            agent.PlaceOrder(new BuyTransaction { Value = "HDFC 10 shares" });
            agent.PlaceOrder(new SellTransaction { Value = "HDFC 5 shares" });
            agent.RedoLastTransaction();
            agent.RedoLastTransaction();
            agent.RedoLastTransaction();
        }

    }
}
