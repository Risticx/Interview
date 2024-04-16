using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        public int Id { get; private set;}

        [Required]
        public string Label { get; set; }

        public Currency(string label) 
        { 
            Label = label; 
        }

    }
}