using Library_CaseStudy_MVC.Models;
using Library_CaseStudy_MVC.Repo.interfaces;
using Library_CaseStudy_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library_CaseStudy_MVC.Controllers
{
    public class BorrowController : Controller
    {
        private readonly IBorrowRepo _borrowRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IMemberRepo _memberRepo;
        public BorrowController(IBorrowRepo borrowRepo, IBookRepo bookRepo, IMemberRepo memberRepo)
        {
            _borrowRepo = borrowRepo;
            _bookRepo = bookRepo;
            _memberRepo = memberRepo;
        }

        public IActionResult Index(string? status)
        {
            var l = _borrowRepo.GetAll(status);
            return View(l);
        }

        public IActionResult Add()
        {
            var vm = new borrowVM
            {
                books= _bookRepo.GetAll().Where(o=>o.availablecopiesnum>0).ToList(),    
                members=_memberRepo.GetAll(),
                borrowdate=DateOnly.FromDateTime(DateTime.Now)
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(borrowVM borrow)
        {
            var b = new Borrow
            {
                bookid= borrow.bookid,
                memberid= borrow.memberid,
                status= "Borrowed",
                borroedate=borrow.borrowdate,
                returndate=borrow.returndate,
            };
          
                _borrowRepo.Add(b);
                var bo =_bookRepo.GetById(borrow.bookid);
                bo.availablecopiesnum--;
                _bookRepo.Save();
                return RedirectToAction("Index");
            
        }


        public IActionResult Return(int id)
        {
            var d=_borrowRepo.GetById(id);
            d.status = "Returned";

            var book = _bookRepo.GetById(d.bookid);
            book.availablecopiesnum++;
            _bookRepo.Save();
            _borrowRepo.Save();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            _borrowRepo.Delete(id);
            return RedirectToAction("Index");
        }

            

    }
}
