using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        DepartmentManager departmentManager = new DepartmentManager();
        public ActionResult Save()
        {
            
            return View();

        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            try
            {

                int rowsAffected = departmentManager.Save(department);
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
            return View();

        }
        public ActionResult Index()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            ViewBag.Department = departmentlist;
            return View();
        }

        
    }
}