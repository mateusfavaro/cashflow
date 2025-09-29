using AutoMapper;
using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Domain.Repositories;
using CashFlowMateus.Domain.Repositories.Expenses;
using CashFlowMateus.Exception;
using CashFlowMateus.Exception.ExceptionBase;

namespace CashFlowMateus.Application.UseCases.Expenses.Update
{
    public class UpdateRequestUseCase : IUpdateRequestUseCase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExpenseUpdateOnlyRepository _repository;


        public UpdateRequestUseCase(IUnitOfWork unitOfWork, IMapper mapper, IExpenseUpdateOnlyRepository repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Execute(long id, RequestExpensesJson request)
        {

            Validate(request);

            var expense = await _repository.GetById(id);

            if (expense == null)
            {
                throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(request, expense);

            _repository.Update(expense);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestExpensesJson request)
        {

            var validator = new ExpensesValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
