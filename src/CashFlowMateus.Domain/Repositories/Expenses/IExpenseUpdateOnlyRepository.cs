using CashFlowMateus.Domain.Entities;

namespace CashFlowMateus.Domain.Repositories.Expenses
{
    public interface IExpenseUpdateOnlyRepository 
    {
        Task<Expense?> GetById(long id);

        void Update(Expense expense);
    }
}
