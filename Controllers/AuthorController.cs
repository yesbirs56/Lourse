using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lourse.Models;
using Lourse.Data;
using System.Data.Entity;

namespace Lourse.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            IEnumerable<Author> authors;
            using (LourseContext context = new LourseContext())
            {
                authors = context.Authors.Include(s => s.Courses).ToList();
            }
            return View(authors);
        }
        public ActionResult Details(int id)
        {
            Author author;
            using (LourseContext context = new LourseContext())
            {
                author = context.Authors.Include(c => c.Courses).SingleOrDefault(c => c.Id == id);
            }
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        public ActionResult Create()
        {
            return View("AuthorForm", new Author());
        }
        public ActionResult Edit(int id)
        {
            Author author;
            using (LourseContext context = new LourseContext())
            {
                author = context.Authors.SingleOrDefault(s => s.Id == id);
            }
            return View("AuthorForm", author);
        }
        public ActionResult Save(Author author)
        {
            if (author.Id == 0)
            {
                using (LourseContext context = new LourseContext())
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                }
            }
            else
            {
                using (LourseContext context = new LourseContext())
                {
                    var oldAuthor = context.Authors.SingleOrDefault(s => s.Id == author.Id);
                    oldAuthor.Name = author.Name;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            using (LourseContext context = new LourseContext())
            {
                var author = context.Authors.SingleOrDefault(s => s.Id == Id);
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}