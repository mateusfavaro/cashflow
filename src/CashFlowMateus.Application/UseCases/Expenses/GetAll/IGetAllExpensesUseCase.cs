using CashFlowMateus.Communication.Responses;

namespace CashFlowMateus.Application.UseCases.Expenses.GetAll
{
    public interface IGetAllExpensesUseCase
    {
        Task<ResponseExpensesJson> Execute();

    }
}
