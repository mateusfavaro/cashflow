using CashFlowMateus.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlowMateus.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {

        public static async Task MigrateDataBase(IServiceProvider serviceProvicer)
        {

            var dbContext = serviceProvicer.GetRequiredService<CashFlowDbContext>();

            await dbContext.Database.MigrateAsync();

        }

    }
}
