using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUCRMS.Models
{
    public class CourseAssignToTeacher
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int Status { get; set; }
        public double CourseCredit { get; set; }
    }
}