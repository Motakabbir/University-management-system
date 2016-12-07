using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class GradeManager
    {
        GradeGateway gradeGateway=new GradeGateway();
        public List<Grade> GetAllGrade()
        {
            return gradeGateway.GetAllGrade();
        }
    }
}