
using CashFlowMateus.Domain.Repositories;
using CashFlowMateus.Domain.Repositories.Expenses;
using CashFlowMateus.Exception;
using CashFlowMateus.Exception.ExceptionBase;

namespace CashFlowMateus.Application.UseCases.Expenses.DeleteById
{
    public class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {

        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, 
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {

            var result = await _repository.Delete(id);

            if(result == false)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
