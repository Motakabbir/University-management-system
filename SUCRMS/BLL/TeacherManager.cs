using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public int Save(Teacher teacher)
        {
            if (IsEmailExist(teacher.Email))
            {
                throw new Exception("Email already exist");
            }
            return teacherGateway.Save(teacher);
        }
        public bool IsEmailExist(string email)
        {
            return teacherGateway.IsEmailExist(email);
        }

        public List<Teacher> GetAllTeacher()
        {
            return teacherGateway.GetAllTeacher();
        }
    }
}