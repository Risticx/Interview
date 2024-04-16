using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class EFTransactionRepository : ITransactionRepository
    {
        private DataContext Context;

        public EFTransactionRepository(DataContext context) 
        {
            Context = context;
        }
        public Transaction getById(string id)
        {
            return Context.Transactions.Where(p => p.Id == id).FirstOrDefault() ?? throw new TransactionNotFoundException();
        }

        public void save(Transaction t)
        {
            Context.Transactions.Add(t);
            Context.SaveChanges();
        }
    }
}