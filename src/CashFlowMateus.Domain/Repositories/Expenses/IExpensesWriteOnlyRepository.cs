using CashFlowMateus.Domain.Entities;

namespace CashFlowMateus.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {

        Task Add(Expense expense);

        /// <summary>
        /// This function returns TRUE if the deletion was sucessful.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);

    }
}
