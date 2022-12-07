using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InAndOut.Models;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
/*        int idNow;*/
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
/*            idNow = obj.Id;*/
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
/*            _db.Items.Update(obj);
            _db.SaveChanges();*/
  /*          return RedirectToAction("Index");*/
            return View();

        }

    }
}
