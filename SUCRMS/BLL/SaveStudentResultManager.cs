using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class SaveStudentResultManager
    {
        SaveStudentResultGateway saveStudentResultGateway = new SaveStudentResultGateway();
        public int Save(SaveStudentResult saveStudentResult)
        {
            if (saveStudentResult.StudentId != 0 && saveStudentResult.CourseId != 0)
            {
                if (IsCourseExist(saveStudentResult.StudentId, saveStudentResult.CourseId))
                {
                    throw new Exception("Grade already given");
                }
                if (IsCourseEnrolled(saveStudentResult.StudentId, saveStudentResult.CourseId))
                {
                    return saveStudentResultGateway.Save(saveStudentResult);
                }
                else
                {
                    throw new Exception("This Course has not been enrolled by this student!");
                }
            }
            else
            {
                throw new Exception("Please Select Student and Course");
            }

        }

        public bool IsCourseExist(int studentId, int CourseId)
        {
            return saveStudentResultGateway.IsCourseExist(studentId, CourseId);
        }

        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        private bool IsCourseEnrolled(int studentId, int courseId)
        {
            return enrollCourseManager.IsCourseEnrolled(studentId, courseId);
        }
    }
}