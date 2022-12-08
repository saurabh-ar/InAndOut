using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense")]
        [Required(ErrorMessage ="Amount cannot be EMPTY!")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Amount cannot be ZERO!")]
        public int Amount { get; set; }

        [DisplayName("Expense Category")]
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]

        [DisplayName("Expense Category")]
        public virtual ExpenseCategory ExpenseCategory { get; set;}
    }
}
