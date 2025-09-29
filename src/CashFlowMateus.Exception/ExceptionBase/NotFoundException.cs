using System.Net;

namespace CashFlowMateus.Exception.ExceptionBase
{
    public class NotFoundException : CashFlowMateusException
    {

        public NotFoundException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
