using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.VIewModel;

namespace ShoppingCart.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        ApplicationDbContext _context;

        public PagesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {
            var pages = _context.Pages.OrderBy(p => p.Sorting).AsEnumerable().Select(p => new PageFormViewModel(p)).ToList();

            return View(pages);
        }

        // GET: Admin/AddPage        
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }

        // POST: Admin/AddPage
        [HttpPost]
        public ActionResult AddPage(PageFormViewModel pageModel)
        {
            if (!ModelState.IsValid)
                return View(pageModel);

            string slug = "";

            if (String.IsNullOrWhiteSpace(pageModel.Slug))
                slug = pageModel.Title.Replace(" ", "-").ToLower();
            else
                slug = pageModel.Slug.Replace(" ", "-").ToLower();

            if (_context.Pages.Any(p => p.Slug == pageModel.Slug) || _context.Pages.Any(p => p.Title == pageModel.Title)) 
            {
                ModelState.AddModelError("", "Title or Slug already exists.");
                return View(pageModel);
            }

            var page = new Page 
            {
                Title = pageModel.Title,
                Slug = slug,
                Body = pageModel.Body,
                Sorting = 100,
                HasSidebar = pageModel.HasSidebar
            };

            _context.Pages.Add(page);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "You have added page!";

            return RedirectToAction("AddPage");
        }

        // GET: Admin/EditPage/id
        [HttpGet]
        public ActionResult EditPage(int id)
        {
            var page = _context.Pages.Find(id);

            if(page == null)
                return Content("The page doesn't exist.");

            return View(new PageFormViewModel(page));
        }

        // POST: Admin/EditPage/id
        [HttpPost]
        public ActionResult EditPage(PageFormViewModel pageModel)
        {
            if (!ModelState.IsValid)
                return View(pageModel);

            var page = _context.Pages.Find(pageModel.Id);

            string slug = "";

            if (pageModel.Slug != "home")
            {
                if (String.IsNullOrWhiteSpace(pageModel.Slug))
                    slug = pageModel.Title.Replace(" ", "-").ToLower();
                else
                    slug = pageModel.Slug.Replace(" ", "-").ToLower();
            }

            if (_context.Pages.Where(p => p.Id != pageModel.Id).Any(p=> p.Title == pageModel.Title) ||
                _context.Pages.Where(p => p.Id != pageModel.Id).Any(p => p.Slug == pageModel.Slug)) 
            {
                ModelState.AddModelError("", "Title or Slug already exist.");
                return View(pageModel);
            }

            page.Title = pageModel.Title;
            page.Slug = slug;
            page.Body = pageModel.Body;
            page.HasSidebar = pageModel.HasSidebar;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "You have edited this page!";
            return RedirectToAction("EditPage");
        }

        // GET: Admin/PageDetials/id
        [HttpGet]
        public ActionResult PageDetails(int id)
        {
            var page = _context.Pages.Find(id);

            if (page == null)
                return Content("The page doesn't exist.");

            return View(new PageFormViewModel(page));
        }

        // GET: Admin/DeletePage/id
        public ActionResult DeletePage(int id)
        {
            var page = _context.Pages.Find(id);

            _context.Pages.Remove(page);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Admin/ReorderPages
        [HttpPost]
        public void ReorderPages(int[] id)
        {
            int count = 1;

            foreach (var item in id)
            {
                var page = _context.Pages.Find(item);
                page.Sorting = count++;

                _context.SaveChanges();
            }
        }

        // GET: Admin/Editsidebar
        [HttpGet]
        public ActionResult EditSidebar()
        {
            var sidebar = _context.Sidebars.Find(1);

            return View(new SidebarFormViewModel(sidebar));
        }

        // POST: Admin/Editsidebar
        [HttpPost]
        public ActionResult EditSidebar(SidebarFormViewModel sidebarModel)
        {
            var sidebar = _context.Sidebars.Find(1);

            sidebar.Body = sidebarModel.Body;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "You have edited the sidebar!";

            return RedirectToAction("EditSidebar");
        }
    }
}