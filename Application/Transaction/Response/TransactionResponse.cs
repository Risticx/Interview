namespace Application.Transaction.Response {

    public enum TransactionStatus {
        Success = 0,
        InvalidPlayer = 1,
        InvalidCurrency = 2
    };
    public class TransactionResponse
    {
        public string? TransactionId { get; set; }
        public string? Message { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionResponse() {}
        public TransactionResponse(string transactionId, string message, int status) {
            TransactionId = transactionId;
            Message = message;
            Status = (TransactionStatus)status;
        }
    }
}
