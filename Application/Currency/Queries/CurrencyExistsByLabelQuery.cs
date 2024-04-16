using Domain.Repositories;

namespace Application.Currency.Queries
{
    public class CurrencyExistsByLabelQuery
    {
        ICurrencyRepository CurrencyRepository;

        public CurrencyExistsByLabelQuery(ICurrencyRepository currencyRepository)
        {
            CurrencyRepository = currencyRepository;
        }
        public bool currencyExistsByLabel(string label)
        {
            return CurrencyRepository.currencyExistsByLabel(label);
        }
    }
}