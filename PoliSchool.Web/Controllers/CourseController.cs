using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;


namespace PoliSchool.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseDao courseDao;
        private readonly IDepartmentDao departmentDao;

        public CourseController(ICourseDao courseDao, IDepartmentDao departmentDao)
        {
            this.courseDao = courseDao;
            this.departmentDao = departmentDao;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var course = this.courseDao.GetCourses().Select(co => new Models.CourseListModel()
            {
                CourseId = co.CourseId,
                CreationDateDisplay = co.CreationDateDisplay,
                Department = co.DepartmentName,
                Name = co.Name,
                EnrollmentDateDisplay = co.EnrollmentDateDisplay
            });


            return View(course);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            var departments = this.departmentDao.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseView)
        {
            try
            {
               // this.courseDao.SaveCourse(new DAL.Entities.Course() {  });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
