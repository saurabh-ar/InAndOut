using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InAndOut.Models
{
    public class VM_Expense
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
