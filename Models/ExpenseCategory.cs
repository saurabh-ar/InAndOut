using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string ExpenseCategoryName { get; set; }    
    }
}
