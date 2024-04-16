using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities 
{
    [Table("User")]
    public class User
    {
        [Key]
        public string? Id { get; private set; }

        [Required]
        public string Username { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Lastname { get; private set; }

        [Required]
        public string Email { get; private set; }

        public List<Transaction>? UserTransactions { get; set; }

        public User(string username, string name, string lastname, string email) 
        {
            Username = username;
            Name = name;
            Lastname = lastname;
            Email = email;
            UserTransactions = new List<Transaction>();
        }
        
    }
}