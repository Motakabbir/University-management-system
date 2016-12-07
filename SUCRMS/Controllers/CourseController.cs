using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /City/

        CourseManager courseManager = new CourseManager();

        public ActionResult Save()
        {
            ViewBag.Department = GetAllDepartments();
            ViewBag.Semester = getAllSemesters();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            try
            {
                CourseManager courseManager = new CourseManager();
                int rowsAffected = courseManager.Save(course);
                if (rowsAffected > 0)
                {
                    ViewBag.Message= "Saved";
                }
                else
                {
                    ViewBag.Message = "Save failed";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Message= exception.Message;
            }
            ViewBag.Department = GetAllDepartments();
            ViewBag.Semester = getAllSemesters();
            return View();
        }

        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            return departmentlist;
        } 

        SemesterManager semesterManager=new SemesterManager();
        private List<Semester> getAllSemesters()
        {
            var semesterlist = semesterManager.GetAllSemesters();
            return semesterlist;
        }

        public ActionResult CourseStatics()
        {
            ViewBag.Department = GetAllDepartments();
            return View();

        }
        [HttpPost]
        public ActionResult CourseStatics(Course course)
        {
            if (course.DepartmentId > 0)
            {
                ViewBag.CourseList = GetCourseInfoByDepartmentId(course.DepartmentId);
            }
            ViewBag.Department = GetAllDepartments();
            return View();
        }

        private List<Course> GetCourseInfoByDepartmentId(int departmentId)
        {
            var courseList = courseManager.GetCourseInfoByDepartmentId(departmentId);
            return courseList;
        }
    }
}