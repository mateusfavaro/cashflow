using AutoMapper;
using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;
using CashFlowMateus.Domain.Repositories;
using CashFlowMateus.Domain.Repositories.User;
using CashFlowMateus.Domain.Security.Cryptography;
using CashFlowMateus.Domain.Security.Tokens;
using CashFlowMateus.Exception;
using CashFlowMateus.Exception.ExceptionBase;
using FluentValidation.Results;

namespace CashFlowMateus.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAcessTokenGenerator _tokenGenerator;

        public RegisterUserUseCase(IMapper mapper, 
            IPasswordEncripter passwordEncripter, 
            IUserReadOnlyRepository userReadOnlyRepository, 
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IAcessTokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ReponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {

            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request); // Com a configuração do imapper, o password vai ser ignorado. //  
            // Após ser ignorado, será atribuido a ele o valor da request, com a criptografia 

            user.Password = _passwordEncripter.Encrypt(request.Password);

            user.UserIdentifier = Guid.NewGuid();

            await _userWriteOnlyRepository.Add(user);

            await _unitOfWork.Commit();

            return new ReponseRegisterUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {

            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExist)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }


            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);

            }
        }
    }
}
