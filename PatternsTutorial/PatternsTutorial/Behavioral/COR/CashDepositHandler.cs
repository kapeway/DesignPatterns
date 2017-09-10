namespace PatternsTutorial.Behavioral.COR
{
    public abstract class CashDepositHandler {
        protected CashDepositHandler NextHandler { get; set; }

        public void SetNextHandler(CashDepositHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void HandleCashDeposit(CashDepositRequest request);
    }
}