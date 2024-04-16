using Domain.Repositories;
using Domain.Exceptions;

namespace Application.Currency.Commands
{
    public class CreateCurrencyCommand
    {
        private ICurrencyRepository CurrencyRepository;
        
        public CreateCurrencyCommand(ICurrencyRepository currencyRepository)
        {
            CurrencyRepository = currencyRepository;
        }
        public void Handle(string label) 
        {
            if(CurrencyRepository.currencyExistsByLabel(label))
                throw new CurrencyExistsByLabelException();

            Domain.Entities.Currency c = new Domain.Entities.Currency(label);
            CurrencyRepository.save(c);
        }
    }
}