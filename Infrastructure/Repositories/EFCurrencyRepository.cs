using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class EFCurrencyRepository : ICurrencyRepository
    {
        private DataContext Context;

        public EFCurrencyRepository(DataContext context) 
        {
            Context = context;
        }
        public Currency getByLabel(string label)
        {
            return Context.Currencies.Where(p => p.Label == label).FirstOrDefault() ?? throw new CurrencyNotFoundException();
        }

        public bool currencyExistsByLabel(string label)
        {
             return Context.Currencies.Any(p => p.Label == label);
        }

        public void save(Currency c)
        {
            Context.Currencies.Add(c);
            Context.SaveChanges();
        }
    }
}