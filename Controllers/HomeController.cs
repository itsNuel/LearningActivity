using Microsoft.AspNetCore.Mvc;
using LearningActivity.Models;
using System.Collections.Generic;

namespace LearningActivity.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Course> _courses = new()
        {
              new Course
               {
                    CourseCode = "SODV3201", CourseName = "Web Programming Foundations", Description = "This course focuses on foundational programming techniques underpinning web application development.Learners plan, design, program, and integrate server-side elements for web applications." },
                    new Course { CourseCode = "SODV3302", CourseName = "Systems Development and Object-Oriented Design", Description = "This course extends object-oriented analysis and design by incorporating design patterns to create interactive applications." },
                    new Course { CourseCode = "DESN3203", CourseName = "Web Design and Development", Description = "In this course, learners design, author, and publish websites meeting current standards. In groups or individually, learners address concerns such as design principles, frameworks, and deployment operability as related to real-world examples." },
                    new Course { CourseCode = "SODV3301", CourseName = "Software Development Techniques", Description = "This course introduces learners to fundamental approaches to software development techniques by using algorithms, data structures and their technique to implementation." },
                    new Course { CourseCode = "MATH3901", CourseName = "Mathematics for Software Development", Description = "This course provides learners with practical mathematical knowledge and skills in relation to computers. Core concepts of linear algebra to solve a system of equations, vector spaces, matrix algebra are the foundation of this course." },
        };
        private Student GetStudentProfile()
        {
            return new Student
            {
                Name = "Chidozie Emmanuel Uzoma",
                Program = "Software Development",
                Background = "Bachelor of Information Science.Imo State University Nigeria, 2021. Relevant Coursework: Information Systems and Networking, Management Information Services (MIS), Information Storage and Retrieval, Information Science.",
                Interests = "Coding, web development, cloud computing, gaming, etc.",
                CareerGoals = "To become a full-stack software engineer after graduation.",
                CurrentCourses = _courses,
            };
        }

        public IActionResult Index()
        {
            var student = GetStudentProfile();
            return View(student);
        }



        public IActionResult Courses()
        {
            var student = GetStudentProfile();
            return View(student.CurrentCourses);
        }

        

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            _courses.Add(course);
            return RedirectToAction(nameof(Courses));
        }



        [HttpGet]
        public IActionResult EditCourse(string? courseCode)
        {
            var course = _courses.FirstOrDefault(item => item.CourseCode == courseCode);

            if (course is null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCourse(string originalCourseCode, Course updatedCourse)
        {
            var existingCourse = _courses.FirstOrDefault(
                course => course.CourseCode == originalCourseCode);

            if (existingCourse is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["OriginalCourseCode"] = originalCourseCode;
                return View(updatedCourse);
            }

            existingCourse.CourseCode = updatedCourse.CourseCode;
            existingCourse.CourseName = updatedCourse.CourseName;
            existingCourse.Description = updatedCourse.Description;

            return RedirectToAction(nameof(Courses));
        }



        public IActionResult AboutMe()
        {
            var student = GetStudentProfile();
            return View(student);
        }
    }
}
