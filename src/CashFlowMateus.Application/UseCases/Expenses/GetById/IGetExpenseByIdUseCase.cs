using CashFlowMateus.Communication.Responses;

namespace CashFlowMateus.Application.UseCases.Expenses.GetById
{
    public interface IGetExpenseByIdUseCase
    {

        Task<ResponseExpenseJson> Execute(long id);

    }
}
