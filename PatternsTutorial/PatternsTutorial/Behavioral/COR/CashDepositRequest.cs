using System;

namespace PatternsTutorial.Behavioral.COR
{
    public class CashDepositRequest
    {
        public CashDepositRequest(Cash cash)
        {
            Cash = cash;
        }

        private Cash Cash { get; }
        public int GetCashValue()
        {
            return Int32.Parse(this.Cash.Value);
        }
    }
}