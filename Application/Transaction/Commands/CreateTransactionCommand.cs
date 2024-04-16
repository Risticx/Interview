using Domain.Repositories;

namespace Application.Transaction.Commands
{
    public class CreateTransactionCommand
    {
        private ITransactionRepository TransactionRepository;

        public CreateTransactionCommand(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        public string? Handle(decimal amount, string message, string currency, int status) 
        {
            Domain.Entities.Transaction t = new Domain.Entities.Transaction(amount, message, currency, status);
            TransactionRepository.save(t);
            return t.Id;
        }
    }
}