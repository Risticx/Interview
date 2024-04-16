using Domain.Entities;
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
        public string? Handle(decimal amount, Domain.Entities.Currency currency, string message, int status) 
        {
            Domain.Entities.Transaction t = new Domain.Entities.Transaction(amount, currency, message, status);
            TransactionRepository.save(t);
            return t.Id;
        }
    }
}