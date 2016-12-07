using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;
using WebGrease.Css.Ast.Selectors;

namespace SUCRMS.Controllers
{
    public class EnrollCourseController : Controller
    {
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        //
        // GET: /EnrollCourse/
        public ActionResult Save()
        {
            ViewBag.Student = GetAllstudents();
            ViewBag.Course = GetAllCourses();
            return View();
        }
        [HttpPost]
        public ActionResult Save(EnrollCourse enrollCourse)
        {
            try
            {

                int rowsAffected = enrollCourseManager.Save(enrollCourse);
                if (rowsAffected > 0)
                {
                    ViewBag.Message = "Saved";
                }
                else
                {
                    ViewBag.Message = "Fail";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
            }
            ViewBag.Student = GetAllstudents();
            ViewBag.Course = GetAllCourses();
            return View();
        }


        StudentManager studentManager = new StudentManager();
        private List<Student> GetAllstudents()
        {
            var studentList = studentManager.GetAllStudent();
            return studentList;
        }
       
        
        public JsonResult GetNameByRegNo(int StudenId)
        {
            List<Student> StudentList = null;
            if (StudenId > 0)
            {
                var students = GetAllstudents();
                StudentList = students.Where(a => a.Id == StudenId).ToList();
            }
            return Json(StudentList, JsonRequestBehavior.AllowGet);
        }
        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            return departmentlist;
        }
        public JsonResult GetdepartmentByRegNo(int departmentId)
        {
            List<Department> DepartmentList = null;
            if (departmentId > 0)
            {
                var department = GetAllDepartments();
                DepartmentList = department.Where(a => a.Id == departmentId).ToList();
            }
            return Json(DepartmentList, JsonRequestBehavior.AllowGet);
        }

        CourseManager courseManager = new CourseManager();
        private List<Course> GetAllCourses()
        {
            var courseList = courseManager.GetAllCourse();
            return courseList;
        }
        public ActionResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> courselList = null;
            if (departmentId > 0)
            {
                var courses = GetAllCourses();
                courselList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            }
            return Json(courselList, JsonRequestBehavior.AllowGet);
        }
	}
}