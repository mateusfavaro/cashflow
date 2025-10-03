using CashFlowMateus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlowMateus.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {

        public CashFlowDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
