using System;

namespace PatternsTutorial.Behavioral.COR
{
    public class HundredRupeeCashHandler : CashDepositHandler
    {
        public override void HandleCashDeposit(CashDepositRequest request)
        {
            if (request.GetCashValue() == 100)
            {
                Console.WriteLine($"Cash will be put on the 100 Rupee Tray :: {this.GetType()}");
            }
            else
            {
                NextHandler?.HandleCashDeposit(request);
            }
        }
    }
}