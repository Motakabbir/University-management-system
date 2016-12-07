using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SUCRMS.BLL;
using SUCRMS.Models;

namespace SUCRMS.Controllers
{
    public class AllocateClassroomController : Controller
    {
        //
        // GET: /AllocateClassroom/

        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();

        public ActionResult Save()
        {
            ViewBag.Department = GetAllDepartments();
            ViewBag.Course = GetAllCourses();
            ViewBag.Day = GetAllDay();
            ViewBag.Room = GetAllRoom();
            return View();
        }

        [HttpPost]
        public ActionResult Save(AllocateClassroom allocateClassroom)
        {
            try
            {
                int rowsAffected = allocateClassroomManager.Save(allocateClassroom);
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
            ViewBag.Course = GetAllCourses();
            ViewBag.Day = GetAllDay();
            ViewBag.Room = GetAllRoom();
            return View();
        }
        DepartmentManager departmentManager = new DepartmentManager();
        private List<Department> GetAllDepartments()
        {
            var departmentlist = departmentManager.GetAllDepartment();
            return departmentlist;
        }

        CourseManager courseManager = new CourseManager();
        private List<Course> GetAllCourses()
        {
            var courseList = courseManager.GetAllCourse();
            return courseList;
        }

        DayManager dayManager = new DayManager();
        private List<Day> GetAllDay()
        {
            var dayList = dayManager.GetAllDay();
            return dayList;
        }

        RoomManager roomManager = new RoomManager();
        private List<Room> GetAllRoom()
        {
            var roomList = roomManager.GetAllRoom();
            return roomList;
        }




        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            List<Course> courseList = null;
            if (departmentId > 0)
            {
                var courses = GetAllCourses();
                courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UnAllocateClassrooms()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAllocateClassrooms(AllocateClassroom allocateClassroom)
        {
            int rowsAffected = allocateClassroomManager.UnAllocateClassrooms(allocateClassroom);
            if (rowsAffected > 0)
            {
                ViewBag.Message = "UnAllocate Classrooms Successfully";
            }
            else
            {
                ViewBag.Message = "UnAllocate failed";
            }
            return View();  
        }

	}
}