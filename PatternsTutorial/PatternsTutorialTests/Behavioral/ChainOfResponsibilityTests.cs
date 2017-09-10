using NUnit.Framework;
using PatternsTutorial.Behavioral.COR;

namespace PatternsTutorialTests.Behavioral
{
    [TestFixture]
    public class ChainOfResponsibilityTests
    {
        [TestCase ("100",100)]
        [TestCase("0", 0)]
        [TestCase("-100", -100)]
        public void CashDepositRequestGetCashValue_StringRupeeBill_ReturnsIntValue(string value, int expectedResult)
        {
            var sut = new CashDepositRequest( new Cash { Value = value } );
            var result = sut.GetCashValue();
            Assert.That(result,Is.EqualTo(expectedResult));
        }

        [Test]
        public void CashDepositHandler_2000RupeeGoesTo_2000Tray()
        {
            var request = new CashDepositRequest(new Cash { Value = "2000"});
            var hundredHandler=new HundredRupeeCashHandler();
            var fiveHundredHandler=new FiveHundredRupeeCashHandler();
            var twoThousandHandler=new TwoThousandRupeeCashHandler();
            hundredHandler.SetNextHandler(fiveHundredHandler);
            fiveHundredHandler.SetNextHandler(twoThousandHandler);
            hundredHandler.HandleCashDeposit(request);
        }

        [Test]
        public void CashDepositHandler_UnknownDenomination_FailSilently()
        {
            var request = new CashDepositRequest(new Cash { Value = "353" });
            var hundredHandler = new HundredRupeeCashHandler();
            var fiveHundredHandler = new FiveHundredRupeeCashHandler();
            var twoThousandHandler = new TwoThousandRupeeCashHandler();
            hundredHandler.SetNextHandler(fiveHundredHandler);
            fiveHundredHandler.SetNextHandler(twoThousandHandler);
            hundredHandler.HandleCashDeposit(request);
        }

    }
}
