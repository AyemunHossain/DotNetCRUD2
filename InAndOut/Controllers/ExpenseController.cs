using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> obj = _db.Expense;
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expense.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is int && id > 0 && id != null)
            {
                var obj = _db.Expense.Find(id);
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expense obj)
        {
            if (ModelState.IsValid)
            {
                if (obj != null)
                {
                    _db.Expense.Update(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }



        public IActionResult Delete(int? id)
        {
            if (id is int && id > 0 && id != null)
            {
                var obj = _db.Expense.Find(id);
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? id)
        {
            if (id is int && id > 0 && id != null)
            {
                var obj = _db.Expense.Find(id);
                _db.Expense.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
