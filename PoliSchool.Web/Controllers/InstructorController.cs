using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Entities;
using PoliSchool.Web.Models;
using school.DAL.Interfaces;

namespace PoliSchool.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorDao instructorDao;

        public InstructorController(IInstructorDao instructorDao)
        {
            this.instructorDao = instructorDao;
        }
        public ActionResult Index()
        {
            var instructos = this.instructorDao.GetInstructors().Select(cd => new Models.InstructorListModel()
            {
                
                HireDate = cd.HireDate,
                HireDateDisplay = cd.HireDateDisplay,
                Id = cd.Id,
                Name = cd.Name
            }).ToList();



            return View(instructos);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {


            var instructorModel = this.instructorDao.GetInstructorById(id);

            InstructorListModel instructor = new InstructorListModel()
            {
                HireDate = instructorModel.HireDate,
                Id = instructorModel.Id,
                Name = instructorModel.Name
            };


            return View(instructor);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorViewModel instructorView)
        {
            try
            {

                Instructor instructorToAdd = new Instructor()
                {
                    LastName = instructorView.LastName,
                    FirstName = instructorView.FirstName,
                    HireDate = instructorView.HireDate,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                };


                this.instructorDao.SaveInstructor(instructorToAdd);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);

            InstructorViewModel instructorViewModel = new InstructorViewModel()
            {
                HireDate = instructorModel.HireDate,
                FirstName = instructorModel.FirstName,
                LastName = instructorModel.LastName,
                Id = instructorModel.Id
            };

            return View(instructorViewModel);
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel instructorViewModel)
        {
            try
            {
                Instructor instructorToUpdate = new Instructor()
                {
                    Id = instructorViewModel.Id,
                    FirstName = instructorViewModel.FirstName,
                    LastName = instructorViewModel.LastName,
                    HireDate = instructorViewModel.HireDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };


                this.instructorDao.UpdateInstructor(instructorToUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Delete/5
       
    }
}
