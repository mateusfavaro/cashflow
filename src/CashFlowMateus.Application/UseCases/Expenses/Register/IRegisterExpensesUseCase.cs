using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;

namespace CashFlowMateus.Application.UseCases.Expenses.Register
{
    public interface IRegisterExpensesUseCase
    {
        Task<ResponseRegisterExpensesJson> Execute(RequestExpensesJson request);

    }
}
