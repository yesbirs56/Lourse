using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Lourse.Models;
using Lourse.Data;
using Lourse.ViewModels;

namespace Lourse.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> courses;
            using (LourseContext context = new LourseContext())
            {
                courses = context.Courses.Include(c=>c.Author).Include(c=>c.Students).ToList();
            }
            return View(courses);
        }

        public ActionResult Details(int id)
        {
            Course course;
            using(LourseContext context = new LourseContext())
            {
                course = context.Courses.Include(c=>c.Author).Include(c=>c.Students).SingleOrDefault(c => c.Id == id);
            }
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        public ActionResult Create()
        {
            IEnumerable<Author> authors;
            using (LourseContext context = new LourseContext())
            { 
                authors = context.Authors.ToList();
            }

            CourseAuthorViewModel courseAuthor = new CourseAuthorViewModel()
            {
                Course = new Course(),
                Authors = authors
            };
            return View("CourseForm", courseAuthor);
        }
        public ActionResult Edit(int id)
        {
            Course course;
            IEnumerable<Author> authors; 
            using (LourseContext context = new LourseContext())
            {
                course = context.Courses.SingleOrDefault(c => c.Id == id);
                authors = context.Authors.ToList();
            }
            CourseAuthorViewModel courseAuthor = new CourseAuthorViewModel()
            {
                Course = course,
                Authors = authors

            };
            return View("CourseForm", courseAuthor);
        }
        public ActionResult Save(CourseAuthorViewModel courseAuthor)
        {
            Course course = courseAuthor.Course;
            if (course.Id == 0)
            {
                course.DatePublished = DateTime.Now;
                
                using (LourseContext context = new LourseContext())
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                }
            }
            else
            {
                using (LourseContext context = new LourseContext())
                {
                    var oldCourse = context.Courses.SingleOrDefault(c => c.Id == course.Id);
                    
                    oldCourse.Title = course.Title;
                    oldCourse.Price = course.Price;
                    oldCourse.Description = course.Description;

                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            using (LourseContext context = new LourseContext())
            {
                var course = context.Courses.SingleOrDefault(s => s.Id == Id);
                context.Courses.Remove(course);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}