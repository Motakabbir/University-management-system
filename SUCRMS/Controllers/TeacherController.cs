using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        public ActionResult Save()
        {
            ViewBag.Department = GetAllDepartments();
            ViewBag.Designation = GetAllDesignations();
            return View();


        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            try
            {
                TeacherManager teacherManager = new TeacherManager();
                int rowsAffected = teacherManager.Save(teacher);
                if (rowsAffected > 0)
                {
                    ViewBag.Message = "Saved";
                }
                else
                {
                    ViewBag.Message = "Save failed";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
            }
            ViewBag.Department = GetAllDepartments();
            ViewBag.Designation = GetAllDesignations();
            return View();
        }


        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            return departmentlist;
        }

        DesignationManager designationManager = new DesignationManager();
        private List<Designation> GetAllDesignations()
        {
            var designationlist = designationManager.GetAllDesignation();
            return designationlist;
        } 
	}
}