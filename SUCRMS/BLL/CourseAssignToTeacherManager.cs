using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class CourseAssignToTeacherManager
    {
        CourseAssignToTeacherGateway courseAssignToTeacherGateway = new CourseAssignToTeacherGateway();
        public int Save(CourseAssignToTeacher courseAssignToTeacher)
        {
            if (courseAssignToTeacher.DepartmentId != null && courseAssignToTeacher.TeacherId != null && courseAssignToTeacher.CourseId != null)
            {
                if (IsCourseAssigned(courseAssignToTeacher.CourseId))
                {
                    throw new Exception("This Course is already Assigned to another Teacher");
                }
                return courseAssignToTeacherGateway.Save(courseAssignToTeacher);
            }
            else
            {
                throw new Exception("Please Provide Department, Teacher and Course Code");
            }
        }

        private bool IsCourseAssigned(int courseId)
        {
            return courseAssignToTeacherGateway.IsCourseAssigned(courseId);
        }

        public int UpdateTeacherRemainCredit(CourseAssignToTeacher courseAssignToTeacher)
        {
            int teacherId = courseAssignToTeacher.TeacherId;
            double courseCredit = courseAssignToTeacher.CourseCredit;
            return courseAssignToTeacherGateway.UpdateTeacherRemainCredit(teacherId, courseCredit);
        }

        public int UnallocationCourseAssignToTeacher(CourseAssignToTeacher courseAssignToTeacher)
        {
            // throw new NotImplementedException();

            return courseAssignToTeacherGateway.UnallocationCourseAssignToTeacher(courseAssignToTeacher);
        }
    }
}