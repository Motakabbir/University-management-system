using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SUCRMS.DAL;
using SUCRMS.Models;

namespace SUCRMS.BLL
{
    public class ClassScheduleManager
    {
        ClassScheduleGateway classScheduleGateway = new ClassScheduleGateway();
        public List<ClassSchedule> GetScheduleByDepartmentId(int departmentId)
        {
            return classScheduleGateway.GetScheduleByDepartmentId(departmentId);
        }
    }
}