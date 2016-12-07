using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        StudentManager studentManager = new StudentManager();

        public ActionResult Save()
        {
            ViewBag.Department = GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            try
            {
                //int rowsAffected = studentManager.Save(student);

                string registrationNo = studentManager.Save(student);
                if (registrationNo!=null)
                {
                    ViewBag.Message = "The Regitration Number Is: " + registrationNo;
                }
                else
                {
                    ViewBag.Message1 = "failed";
                    ViewBag.Message = "Save failed";
                }
            }
            catch (Exception exception)
            {
                ViewBag.Message1 = "failed";
                ViewBag.Message = exception.Message;
            }

            ViewBag.Department = GetAllDepartments();
            return View();
        }

        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            return departmentManager.GetAllDepartment();
        }
    }
}