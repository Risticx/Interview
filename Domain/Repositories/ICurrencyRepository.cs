using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICurrencyRepository
    {
        public Currency getByLabel(string label);
        public bool currencyExistsByLabel(string label);
        public void save(Currency t);
    }
}