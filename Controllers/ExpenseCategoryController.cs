using Microsoft.AspNetCore.Mvc;
using InAndOut.Models;
using System.Collections.Generic;
namespace InAndOut.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ExpenseCategoryHome()
        {
            IEnumerable<ExpenseCategory> objList = _db.ExpenseCategories;
            return View(objList);
        }


        // GET : CREATE
        public IActionResult ExpenseCategoryCreate()
        {
            return View();
        }

        // POST : CREATE
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult ExpenseCategoryCreate(ExpenseCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseCategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ExpenseCategoryHome");
            }
            else
            {
                ModelState.AddModelError("", "Server Side Validation : User Input is Invalid");
                return View();
            }
        }

        // GET : DELETE
        public IActionResult ExpenseCategoryDelete(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }

            ExpenseCategory obj = _db.ExpenseCategories.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        // POST : DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExpenseCategoryDeletePost(int? id)
        {
            ExpenseCategory obj = _db.ExpenseCategories.Find(id);
            if (obj == null)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }
            else
            {
                _db.ExpenseCategories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("ExpenseCategoryHome");
            }

        }

        // GET : Update
        public IActionResult ExpenseCategoryUpdate(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "No Entry Found to Delete");
                return NotFound();
            }

            ExpenseCategory obj = _db.ExpenseCategories.Find(id);
            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //POST : Update

        public IActionResult ExpenseCategoryUpdatePost(ExpenseCategory obj)
        {
            if (obj == null)
                return NotFound();

            _db.ExpenseCategories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("ExpenseCategoryHome");
        }


    }
}
