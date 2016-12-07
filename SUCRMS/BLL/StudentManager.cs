using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public string Save(Student student)
        {
            if (IsEmailExist(student.Email))
            {
                throw new Exception("Email already exist");
            }

            return studentGateway.Save(student);
        }

        
        public bool IsEmailExist(string email)
        {
            return studentGateway.IsEmailExist(email);
        }
        public List<Student> GetAllStudent()
        {
            return studentGateway.GetAllStudent();
        }
    }
}