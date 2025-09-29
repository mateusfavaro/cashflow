namespace CashFlowMateus.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
