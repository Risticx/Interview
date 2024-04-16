namespace Application.Transaction.Response {
    public class TransactionResponse
    {
        public string TransactionId { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        
        public TransactionResponse(string transactionId, string message, int status) {
            TransactionId = transactionId;
            Message = message;
            Status = status;
        }
    }
}
