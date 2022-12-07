using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InAndOut.Models;
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
            IEnumerable<Expense> expenseList = _db.Expenses;
            return View(expenseList);
        }

        // GET : CREATE
        public IActionResult ExpenseCreate()
        {
            return View();
        }

        // POST : CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ExpenseCreate(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
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

            Expense obj = _db.Expenses.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //POST : Update

        public IActionResult ExpenseUpdatePost(Expense obj)
        {
            if (obj == null)
                return NotFound();

            _db.Expenses.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("ExpenseHome");
        }

    }
}
