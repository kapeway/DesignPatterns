using System;

namespace PatternsTutorial.Behavioral.COR
{
    public class FiveHundredRupeeCashHandler : CashDepositHandler
    {
        public override void HandleCashDeposit(CashDepositRequest request)
        {
            if (request.GetCashValue() == 500)
            {
                Console.WriteLine($"Cash will be put on the 500 Rupee Tray :: {this.GetType()}");
            }
            else
            {
                NextHandler?.HandleCashDeposit(request);
            }
        }
    }
}