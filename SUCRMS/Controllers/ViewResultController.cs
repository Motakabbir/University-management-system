using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class ViewResultController : Controller
    {
        //
        // GET: /ViewResult/
        StudentManager studentManager = new StudentManager();
        public ActionResult Index()
        {
            ViewBag.Student = studentManager.GetAllStudent();
            return View();
        }

        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        public JsonResult GetResultByStudentId(int studenId)
        {
            List<ResultView> resultList = null;
            if (studenId > 0)
            {
                var results = GetAllResult();
                resultList = results.Where(a => a.StudenId == studenId).ToList();
            }
            return Json(resultList, JsonRequestBehavior.AllowGet);
        }

        private List<ResultView> GetAllResult()
        {
            var resultList = enrollCourseManager.GetAllResult();
            return resultList;
        }
    }
}