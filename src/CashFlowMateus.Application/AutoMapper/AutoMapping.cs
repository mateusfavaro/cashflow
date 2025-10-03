using AutoMapper;
using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Communication.Responses;
using CashFlowMateus.Domain.Entities;

namespace CashFlowMateus.Application.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestExpensesJson, Expense>();
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<Expense, ResponseRegisterExpensesJson>();
            CreateMap<Expense, ResponseShortExpenseJson>();
            CreateMap<Expense, ResponseExpenseJson>();
        }

    }
}
