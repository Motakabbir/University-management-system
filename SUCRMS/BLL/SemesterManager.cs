using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemesters()
        {
            return semesterGateway.GetAllSemester();
        }
    }
}