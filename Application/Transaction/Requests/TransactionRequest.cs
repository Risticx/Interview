namespace Application.Transaction.Requests {
    public class TransactionRequest
    {
        public string ExternalTransactionId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public TransactionRequest(string externalTransactionId, string userId, decimal amount, string currency) 
        {
            ExternalTransactionId = externalTransactionId;
            UserId = userId;
            Amount = amount;
            Currency = currency;
        }
    }
}
