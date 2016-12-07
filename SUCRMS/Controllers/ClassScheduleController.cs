using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class ClassScheduleController : Controller
    {
        //
        // GET: /ClassSchedule/
        ClassScheduleManager classScheduleManager = new ClassScheduleManager();

        public ActionResult Index()
        {
            ViewBag.Department = GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClassSchedule classSchedule)
        {
            if (classSchedule.DepartmentId > 0)
            {
                ViewBag.ClassScheduleList = GetScheduleByDepartmentId(classSchedule.DepartmentId);
            }
            ViewBag.Department = GetAllDepartments();
            return View();
        }

        private List<ClassSchedule> GetScheduleByDepartmentId(int departmentId)
        {
            var classScheduleList = classScheduleManager.GetScheduleByDepartmentId(departmentId);
            return classScheduleList;
        }

        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            return departmentlist;
        } 
	}
}