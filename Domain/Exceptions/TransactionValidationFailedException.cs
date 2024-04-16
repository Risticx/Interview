namespace Domain.Exceptions 
{
    public class TransactionValidationFailderException : Exception
    {
        public TransactionValidationFailderException() : base("Transaction hash validation failed.") {}
    }
}