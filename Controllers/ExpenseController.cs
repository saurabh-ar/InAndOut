using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult ExpenseHome()
        {
            IEnumerable<Expense> objList = _db.Expenses;

            //Asscoiciate Each 'Expense' we are attaching an Expense Category

            foreach(var obj in objList)
            {
                obj.ExpenseCategory = _db.ExpenseCategories.FirstOrDefault(u => u.Id == obj.ExpenseCategoryId);
            }


            return View(objList);
        }

        // GET : CREATE
        public IActionResult ExpenseCreate()
        {
            /* w/o Expense View Model */

            //IEnumerable<SelectListItem> TypeDropdown = _db.ExpenseCategories.Select(i => new SelectListItem
            //{
            //    Text = i.ExpenseCategoryName,
            //    Value = i.Id.ToString()
            //}); 

            //ViewBag.TypeDropdown = TypeDropdown;

            /***************************/

            VM_Expense vM_Expense = new VM_Expense()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseCategories.Select(i => new SelectListItem
                {
                    Text = i.ExpenseCategoryName,
                    Value = i.Id.ToString()
                })
            };

            return View(vM_Expense);
        }

        // POST : CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ExpenseCreate(VM_Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj.Expense);
                _db.SaveChanges();
                return RedirectToAction("ExpenseHome");
            }
            else
            {
                ModelState.AddModelError("", "Server Side Validation : User Input is Invalid");
                return View();
            }
        }

        // GET : DELETE
        public IActionResult ExpenseDelete(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }

            Expense obj = _db.Expenses.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        // POST : DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExpenseDeletePost(int? id)
        {
            Expense obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }
            else
            {
                _db.Expenses.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("ExpenseHome");
            }

        }

        // GET : Update
        public IActionResult ExpenseUpdate(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }
            VM_Expense vM_Expense = new VM_Expense()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseCategories.Select(i => new SelectListItem
                {
                    Text = i.ExpenseCategoryName,
                    Value = i.Id.ToString()
                })
            };
            vM_Expense.Expense = _db.Expenses.Find(id);

            if (vM_Expense == null)
                return NotFound();

            return View(vM_Expense);
        }

        //POST : Update

        public IActionResult ExpenseUpdatePost(VM_Expense obj)
        {
            if (obj == null)
                return NotFound();

            _db.Expenses.Update(obj.Expense);
            _db.SaveChanges();
            return RedirectToAction("ExpenseHome");
        }

    }
}
