using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_CaseStudy_MVC.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberRepo _repo;
        public MemberController(IMemberRepo repo)
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
        public IActionResult Add(Member member)
        {
            _repo.Add(member);
            return RedirectToAction("Index");
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
        public IActionResult Edit(Member member)
        {
            _repo.Update(member);
            return RedirectToAction("Index");
        }
    }
}
