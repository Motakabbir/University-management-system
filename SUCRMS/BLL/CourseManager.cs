using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();
        public int Save(Course course)
        {
            if (IsCodeExist(course.Code))
            {
                throw new Exception("Course Code already exist");
            }
            else if (IsNameExist(course.Name))
            {
                throw new Exception("Course Name already exist");
            }
            return courseGateway.Save(course);
        }
        public bool IsCodeExist(string code)
        {
            return courseGateway.IsCodeExist(code);
        }
        public bool IsNameExist(string name)
        {
            return courseGateway.IsNameExist(name);
        }

        public List<Course> GetAllCourse()
        {
            return courseGateway.GetAllCourse();
        }

        public List<Course> GetCourseInfoByDepartmentId(int departmentId)
        {
            return courseGateway.GetCourseInfoByDepartmentId(departmentId);
        }
    }
}