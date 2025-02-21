using Microsoft.AspNetCore.Mvc;
using EnglishLearning.Models;
using EnglishLearning.Models.Identity;
using EnglishLearning.Repository;
using System.Collections.Generic;

namespace EnglishLearning.Controllers
{
    public class EnrollmentController : Controller
    {
        IEnrollmentRepository enrollmentRepository;
        ICourseRepository courseRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.courseRepository = courseRepository;

        }

        public IActionResult Index()
        {
            List<Enrollment> enrollmentList = enrollmentRepository.GetAll();
            return View(enrollmentList);
        }


        public IActionResult Create(int courseId, string userId)
        {

            Enrollment enrol = new Enrollment() { CourseId = courseId, UserId = userId, CourseDegree = 0 };
            enrollmentRepository.Insert(enrol);
            return RedirectToAction("Index", "Courses");


        }








    }
}
