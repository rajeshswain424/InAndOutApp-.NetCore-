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
        ApplicationDbcontext db_;

        public ItemController(ApplicationDbcontext dbcontext)
        {
            db_ = dbcontext;
        }
        public IActionResult Index()
        {
           var items= db_.Items;
            return View(items);
        }
        //Get Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            db_.Items.Add(item);
            db_.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
