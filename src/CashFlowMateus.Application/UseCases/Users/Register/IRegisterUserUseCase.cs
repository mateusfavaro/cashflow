using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;

namespace CashFlowMateus.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {

        Task<ReponseRegisterUserJson> Execute(RequestRegisterUserJson request);

    }
}
