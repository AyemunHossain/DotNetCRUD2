using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> obj = _db.Item;
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Item.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is int && id > 0 && id != null)
            {
                var obj = _db.Item.Find(id);
                return View(obj);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item obj)
        {
            if (ModelState.IsValid)
            {
                if (obj != null)
                {
                    _db.Item.Update(obj);
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
                var obj = _db.Item.Find(id);
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
                var obj = _db.Item.Find(id);
                _db.Item.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }




    }
}
