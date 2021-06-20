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
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> students;
            using(LourseContext context = new LourseContext())
            {
                students = context.Students.Include(s=>s.Courses).ToList();
            }
            return View(students);
        }

        public ActionResult Create()
        {
            return View("StudentForm", new Student());
        }
        public ActionResult Edit(int id)
        {
            Student student;
            using(LourseContext context = new LourseContext())
            {
                student = context.Students.SingleOrDefault(s => s.Id == id);
            }
            return View("StudentForm", student);
        }
        public ActionResult Save(Student student)
        {
            if (student.Id == 0)
            {
                using(LourseContext context = new LourseContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
            }
            else
            {
                using(LourseContext context = new LourseContext())
                {
                    var oldStudent = context.Students.SingleOrDefault(s => s.Id == student.Id);
                    oldStudent.Name = student.Name;
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            using (LourseContext context = new LourseContext())
            {
                var oldStudent = context.Students.SingleOrDefault(s => s.Id == Id);
                context.Students.Remove(oldStudent);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}