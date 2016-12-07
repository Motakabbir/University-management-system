using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.DAL;

namespace SUCRMS.Controllers
{
    public class HomeController : Controller
    {
        HomeGateway homeGateway = new HomeGateway();
        public ActionResult Index()
        {
            int countTeacher = homeGateway.CountTeacher();
            ViewBag.CountTeacher = countTeacher;

            int countStudent = homeGateway.CountStudent();
            ViewBag.CountStudent = countStudent;

            int countDepartment = homeGateway.CountDepartment();
            ViewBag.CountDepartment = countDepartment;

            int countCourse = homeGateway.CountCourse();
            ViewBag.CountCourse = countCourse;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}