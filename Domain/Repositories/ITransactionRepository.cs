using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITransactionRepository
    {
        public Transaction getById(string id);
        public void save(Transaction t);
    }
}