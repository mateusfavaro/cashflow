using AutoMapper;
using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;
using CashFlowMateus.Domain.Entities;
using CashFlowMateus.Domain.Repositories;
using CashFlowMateus.Domain.Repositories.Expenses;
using CashFlowMateus.Exception.ExceptionBase;

namespace CashFlowMateus.Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase : IRegisterExpensesUseCase
    {

        private readonly IExpensesWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterExpensesUseCase(
            IExpensesWriteOnlyRepository repository, 
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
             _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisterExpensesJson> Execute(RequestExpensesJson request)
        {

            Validate(request);

            var entity = _mapper.Map<Expense>(request);

            await _repository.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisterExpensesJson>(entity);
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
