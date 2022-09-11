using SalesManagement.Data;
using SalesManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.ViewModels;
using System.Linq;

namespace SalesManagement.Controllers
{
    public class SalesmanController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SalesmanController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            var obj = _db.Salesmen.ToList();

            return View(obj);
            
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Salesman obj)
        {
            if (ModelState.IsValid)
            {
                _db.Salesmen.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Salesmen.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Salesman obj)
        {
            if (ModelState.IsValid)
            {
                _db.Salesmen.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Salesmen.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Salesmen.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Salesmen.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Salesman/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var obj = _db.Salesmen.Find(id);

            var obj = new SalesmanDetailsVM();

            obj.Salesman = _db.Salesmen.Find(id);

            obj.Sales = _db.Sales.Where(s => s.SalesmanId == id && s.SaleDate.Year == DateTime.Now.Year).GroupBy(s => s.SaleDate.Month).Select(s => new SaleVM { Month = s.Key , Amount = s.Sum(sa => sa.Amount), Commission = s.Sum(sa => sa.Commission) }).ToList();

            if (obj.Salesman == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
