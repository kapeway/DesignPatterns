using System;

namespace PatternsTutorial.Behavioral.COR
{
    public class TwoThousandRupeeCashHandler : CashDepositHandler
    {
        public override void HandleCashDeposit(CashDepositRequest request)
        {
            if (request.GetCashValue() == 2000)
            {
                Console.WriteLine($"Cash will be put on the 2000 Rupee Tray :: {this.GetType()}");
            }
            else
            {
                NextHandler?.HandleCashDeposit(request);
            }
        }
    }
}