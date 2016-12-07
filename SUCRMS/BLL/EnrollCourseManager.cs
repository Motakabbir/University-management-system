using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;
using ViewResult = System.Web.Mvc.ViewResult;

namespace SUCRMS.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();
        public int Save(EnrollCourse enrollCourse)
        {
            if (enrollCourse.StudenId !=0 && enrollCourse.CourseId != 0)
            {
                if (IsCourseExist(enrollCourse.StudenId, enrollCourse.CourseId))
                {
                    throw new Exception("This Course has already been enrolled by this student!");
                }
              
                return enrollCourseGateway.Save(enrollCourse);
            }
            else
            {
                throw new Exception("Please Select Student and Course");
            }

        }

        public bool IsCourseExist(int studentId, int CourseId)
        {
            return enrollCourseGateway.IsCourseExist(studentId, CourseId);
        }

        public bool IsCourseEnrolled(int studentId, int courseId)
        {
            return enrollCourseGateway.IsCourseEnrolled(studentId, courseId);
        }

        public List<ResultView> GetAllResult()
        {
            return enrollCourseGateway.GetAllResult();
        }
    }
}