using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public string? Id {get; private set;}

        [Required]
        public decimal Amount { get; private set; }

        [Required]
        public string Currency { get; private set; }

        [Required]
        public string Message{ get; private set; }

        [Required]
        public int Status { get; private set; }

        public Transaction(decimal amount, string currency, string message, int status)
        {
            Amount = amount;
            Currency = currency;
            Message = message;
            Status = status;
        }
    }
}