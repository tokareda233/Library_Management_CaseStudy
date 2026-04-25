using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_CaseStudy_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo _repo;
        public BookController(IBookRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var l = _repo.GetAll();
            return View(l);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
            
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var i = _repo.GetById(id);
            return View(i);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            _repo.Update(book);
            return RedirectToAction("Index");
        }
    }
}
