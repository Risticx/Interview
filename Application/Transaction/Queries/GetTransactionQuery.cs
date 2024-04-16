using Domain.Repositories;

namespace Application.Transaction.Queries
{
    public class GetTransactionQuery
    {
        private ITransactionRepository TransactionRepository;

        public GetTransactionQuery(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        public Domain.Entities.Transaction getById(string id) 
        {
            return TransactionRepository.getById(id);
        }
    }
}