using CashFlowMateus.Application.AutoMapper;
using CashFlowMateus.Application.UseCases.Expenses.DeleteById;
using CashFlowMateus.Application.UseCases.Expenses.GetAll;
using CashFlowMateus.Application.UseCases.Expenses.GetById;
using CashFlowMateus.Application.UseCases.Expenses.Register;
using CashFlowMateus.Application.UseCases.Expenses.Reports.Excel;
using CashFlowMateus.Application.UseCases.Expenses.Update;
using CashFlowMateus.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowMateus.Application
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCase(services);
            AddAutoMapper(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<IRegisterExpensesUseCase, RegisterExpensesUseCase>();
            services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
            services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
            services.AddScoped<IUpdateRequestUseCase, UpdateRequestUseCase>();
            services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }
    }
}
