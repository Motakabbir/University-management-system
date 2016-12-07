using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class SaveStudentResultController : Controller
    {
        //
        // GET: /SaveStudentResult/
        SaveStudentResultManager saveStudentResultManager = new SaveStudentResultManager();
        //
        // GET: /EnrollCourse/
        public ActionResult Save()
        {
            ViewBag.Student = GetAllstudents();
            
            ViewBag.Grade = GetAllGrades();
            return View();
        }
        [HttpPost]
     
        public ActionResult Save(SaveStudentResult saveStudentResult)
        {
            try
            {

                int rowsAffected = saveStudentResultManager.Save(saveStudentResult);
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
            
            ViewBag.Grade = GetAllGrades();
            return View();
        }
        StudentManager studentManager = new StudentManager();
        private List<Student> GetAllstudents()
        {
            var studentList = studentManager.GetAllStudent();
            return studentList;
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

        GradeManager gradeManager = new GradeManager();
        private List<Grade> GetAllGrades()
        {
            var GradeList = gradeManager.GetAllGrade();
            return GradeList;
        }
	}
}