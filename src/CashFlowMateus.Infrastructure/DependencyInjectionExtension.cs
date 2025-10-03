using CashFlowMateus.Domain.Repositories;
using CashFlowMateus.Domain.Repositories.Expenses;
using CashFlowMateus.Domain.Repositories.User;
using CashFlowMateus.Domain.Security.Cryptography;
using CashFlowMateus.Domain.Security.Tokens;
using CashFlowMateus.Infrastructure.DataAccess;
using CashFlowMateus.Infrastructure.DataAccess.Repositories;
using CashFlowMateus.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowMateus.Infrastructure
{
    public static class DependencyInjectionExtension
    {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddToken(services, configuration);
            AddRepositories(services);

            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();

        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            // Esse getvalue vem da biblioteca nugget instalada configuration.binder
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
            services.AddScoped<IExpenseUpdateOnlyRepository, ExpensesRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();

        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Connection");

            var version = new Version(8, 0, 43);
            var serverVersion = new MySqlServerVersion(version);


            services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }
    }
}
