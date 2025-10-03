using CashFlowMateus.Domain.Entities;

namespace CashFlowMateus.Domain.Security.Tokens
{
    public interface IAcessTokenGenerator
    {

        string Generate(User user);

    }
}
