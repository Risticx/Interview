using Domain.Repositories;

namespace Application.Currency.Queries
{
    public class GetCurrencyQuery
    {
        private ICurrencyRepository CurrencyRepository;

        public GetCurrencyQuery(ICurrencyRepository currencyRepository)
        {
            CurrencyRepository = currencyRepository;
        }

        public Domain.Entities.Currency GetByLabel(string label) 
        {
            return CurrencyRepository.getByLabel(label);
        }
    }
}