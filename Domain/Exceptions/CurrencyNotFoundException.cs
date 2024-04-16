namespace Domain.Exceptions 
{
    public class CurrencyNotFoundException : Exception
    {
        public CurrencyNotFoundException() : base("Currency not found.") {}
    }
}