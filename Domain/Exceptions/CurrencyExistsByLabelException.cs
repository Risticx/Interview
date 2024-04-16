namespace Domain.Exceptions 
{
    public class CurrencyExistsByLabelException : Exception
    {
        public CurrencyExistsByLabelException() : base("Currency exists.") {}
    }
}