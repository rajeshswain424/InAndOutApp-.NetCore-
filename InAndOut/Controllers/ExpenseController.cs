using InAndOut.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InAndOut.Models;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        ApplicationDbcontext db_;

        public ExpenseController(ApplicationDbcontext dbcontext)
        {
            db_ = dbcontext;
        }
        public IActionResult Index()
        {
            var expenses = db_.Expenses;
            return View(expenses);
        }
        //Get Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db_.Expenses.Add(expense);
                db_.SaveChanges();
                return RedirectToAction("index");
            }
            return View(expense);
        }

     //get upadte
        public IActionResult Update(int? id)
        {
           var expensedata= db_.Expenses.FirstOrDefault(x => x.Id ==id);
           
          
            return View(expensedata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db_.Expenses.Update(expense);
                db_.SaveChanges();
                return RedirectToAction("index");
            }
            return View(expense);
        }

        public IActionResult Delete(int? id)
        {
            var expensedata = db_.Expenses.FirstOrDefault(x => x.Id == id);


            return View(expensedata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
             var expenseobject=db_.Expenses.FirstOrDefault(x=>x.Id==id);

            db_.Expenses.Remove(expenseobject);
            db_.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
