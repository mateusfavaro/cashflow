namespace CashFlowMateus.Exception.ExceptionBase
{
    public abstract class CashFlowMateusException : System.Exception
    {

        protected CashFlowMateusException(string message) : base(message)
        {
            
        }

        public abstract int StatusCode { get; }
        public abstract List<string> GetErrors();

    }
}
