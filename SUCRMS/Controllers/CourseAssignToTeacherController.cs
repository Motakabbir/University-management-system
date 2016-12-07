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
    public class CourseAssignToTeacherController : Controller
    {
        //
        // GET: /CourseAssignToTeacher/
        CourseAssignToTeacherManager courseAssignToTeacherManager = new CourseAssignToTeacherManager();
        public ActionResult Index()
        {
            ViewBag.Departments = GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseAssignToTeacher courseAssignToTeacher)
        {
            try
            {
                int rowsAffected = courseAssignToTeacherManager.Save(courseAssignToTeacher);
                int updated = courseAssignToTeacherManager.UpdateTeacherRemainCredit(courseAssignToTeacher);
                if (rowsAffected > 0 && updated > 0)
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
            ViewBag.Departments = GetAllDepartments();
            return View();

        }

        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            return departmentManager.GetAllDepartment();
        }

        TeacherManager teacherManager = new TeacherManager();
        private List<Teacher> GetAllTeacher()
        {
            return teacherManager.GetAllTeacher();
        }

        CourseManager courseManager = new CourseManager();
        private List<Course> GetAllCourse()
        {
            return courseManager.GetAllCourse();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            List<Teacher> teacherList = null;
            if (departmentId > 0)
            {
                var teachers = GetAllTeacher();
                teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            }
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> courselList = null;
            if (departmentId > 0)
            {
                var courses = GetAllCourse();
                courselList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            }
            return Json(courselList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTeacherInfoByTeacherId(int teacherId)
        {
            List<Teacher> teacherList = null;
            if (teacherId > 0)
            {
                var teachers = GetAllTeacher();
                teacherList = teachers.Where(a => a.Id == teacherId).ToList();
            }
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourseInfoByCourseId(int courseId)
        {
            List<Course> courseList = null;
            if (courseId > 0)
            {
                var courses = GetAllCourse();
                courseList = courses.Where(a => a.Id == courseId).ToList();
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnallocationCourseAssignToTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnallocationCourseAssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {
            int rowsAffected = courseAssignToTeacherManager.UnallocationCourseAssignToTeacher(courseAssignToTeacher);
            if (rowsAffected > 0)
            {
                ViewBag.Message = "Unassign Teacher Successfully";
            }
            else
            {
                ViewBag.Message = "Unassign failed";
            }
            return View();
        }
    }
}