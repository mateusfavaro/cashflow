using CashFlowMateus.Communication.Requests;

namespace CashFlowMateus.Application.UseCases.Expenses.Update
{
    public interface IUpdateRequestUseCase
    {

        Task Execute(long id, RequestExpensesJson request);
        
    }
}
